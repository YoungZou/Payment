using Gbi.Common;
using Gbi.Payment.Contract;
using Gbi.Payment.Core;
using Gbi.Payment.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Gbi.Payment.Web
{
    /// <summary>
    /// Summary description for NotifyService
    /// </summary>
    public class NotifyService : BasicService, IHttpHandler
    {
        /// <summary>
        /// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler" /> interface.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpContext" /> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.</param>
        public override void ProcessRequest(HttpContext context)
        {
            TradingOrderStatus orderStatus = TradingOrderStatus.Pending;
            string returnResult = null;
            string orderKey = null;

            try
            {
                var requestUrl = context.Request.Url;
                var parameters = WebUtil.Instance.ConvertKeyValuePairCollectionFromString(requestUrl.Query.Trim('?'));

                if (parameters != null && parameters.Count > 0)
                {
                    if (this.IsNotificationAuthenticated(parameters))
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(parameters["notify_data"]);

                        orderKey = xmlDoc.SelectSingleNode("/notify/out_trade_no").InnerText;
                        string tradeNumber = xmlDoc.SelectSingleNode("/notify/trade_no").InnerText;

                        string tradeStatus = xmlDoc.SelectSingleNode("/notify/trade_status").InnerText;
                        returnResult = tradeStatus;

                        if (tradeStatus == "TRADE_FINISHED" || tradeStatus == "TRADE_SUCCESS")
                        {
                            returnResult = "success";
                            orderStatus = TradingOrderStatus.Succeed;
                        }
                    }
                    else
                    {
                        returnResult = "fail";
                        orderStatus = TradingOrderStatus.Failed;
                    }
                }
                else
                {
                    returnResult = "无通知参数";
                }
            }

            catch (Exception ex)
            {
                returnResult = ex.ToString();
            }

            /*
             * update order status in DB
             */
            try
            {
                var service = new PaymentService();
                service.UpdateTradingOrderState(Guid.Parse(orderKey), orderStatus);
            }
            catch (Exception dbException)
            {
                Framework.Instance.HandleExceptionToServiceException("UpdateTradingOrderState", dbException, orderKey);
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write(returnResult);
        }

        /// <summary>
        /// Determines whether [is notification authenticated] [the specified dictionary].
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns><c>true</c> if [is notification authenticated] [the specified dictionary]; otherwise, <c>false</c>.</returns>
        private bool IsNotificationAuthenticated(Dictionary<string, string> dictionary)
        {
            if (dictionary != null)
            {
                return this.IsNotificationFromAlipay(dictionary["notify_data"]) && this.IsSignCorrect(dictionary);
            }
            return false;
        }

        /// <summary>
        /// Determines whether [is notification from alipay] [the specified notify data].
        /// </summary>
        /// <param name="notifyData">The notify data.</param>
        /// <returns><c>true</c> if [is notification from alipay] [the specified notify data]; otherwise, <c>false</c>.</returns>
        private bool IsNotificationFromAlipay(string notifyData)
        {
            try
            {
                if (!string.IsNullOrEmpty(notifyData))
                {
                    string notifyId = "";

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(notifyData);
                    notifyId = xmlDoc.SelectSingleNode("/notify/notify_id").InnerText;

                    if (!string.IsNullOrEmpty(notifyId))
                    {
                        string veryfyUrl = AliServiceConfig.AliVerifyUrl + "partner=" + this.TransactionInfo.Partner + "&notify_id=" + notifyId;
                        return (veryfyUrl.GetHttpResponseString().ToLower() == "true");
                    }
                }
            }

            catch { }

            return false;
        }

        /// <summary>
        /// Determines whether [is sign correct] [the specified dictionary].
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns><c>true</c> if [is sign correct] [the specified dictionary]; otherwise, <c>false</c>.</returns>
        private bool IsSignCorrect(Dictionary<string, string> dictionary)
        {
            if (dictionary != null)
            {
                var client = new PaymentClient(this.TransactionInfo);
                string signed = client.GetSignedString(dictionary);

                return dictionary["sign"] == signed;
            }
            return false;
        }
    }
}