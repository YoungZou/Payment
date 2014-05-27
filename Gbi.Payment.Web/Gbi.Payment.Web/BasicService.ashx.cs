using Gbi.Common;
using Gbi.Payment.Contract;
using Gbi.Payment.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace Gbi.Payment.Web
{
    /// <summary>
    /// Summary description for BasicService
    /// </summary>
    public abstract class BasicService : IHttpHandler
    {
        /// <summary>
        /// The transaction information
        /// </summary>
        protected TransactionInfo TransactionInfo = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicService"/> class.
        /// </summary>
        public BasicService()
        {
            this.TransactionInfo = CreateDefaultTransactionInfo();
        }

        /// <summary>
        /// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler" /> interface.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpContext" /> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.</param>
        public abstract void ProcessRequest(HttpContext context);

        /// <summary>
        /// Gets a value indicating whether another request can use the <see cref="T:System.Web.IHttpHandler" /> instance.
        /// </summary>
        /// <value><c>true</c> if this instance is reusable; otherwise, <c>false</c>.</value>
        /// <returns>true if the <see cref="T:System.Web.IHttpHandler" /> instance is reusable; otherwise, false.</returns>
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Creates the default transaction information.
        /// initializes a default PaymentClient with TransactionInfo from config files.
        /// </summary>
        /// <returns>TransactionInfo.</returns>
        protected TransactionInfo CreateDefaultTransactionInfo()
        {
            return new TransactionInfo()
            {
                Partner = Framework.Partner,
                Key = Framework.Key,
                SellerAccountName = Framework.SellerAccountName,
                NotifyUrl = Framework.NotifyUrl,
                CallBackUrl = Framework.CallBackUrl,
                MerchantUrl = Framework.MerchantUrl,
                Type = TransactionType.AliMobilePayment,
                ServiceName = "HealthService"
            };
        }

        /// <summary>
        /// Gets the json parameter.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="Gbi.OperationFailureException">GetJsonParameter</exception>
        protected string GetJsonParameter(HttpRequest request)
        {
            string jsonParameter = null;

            try
            {
                var bytes = WebUtil.Instance.GetPostDataFromHttpWebRequest(request);
                jsonParameter = Encoding.UTF8.GetString(bytes);
            }
            catch (Exception ex)
            {
                throw new OperationFailureException("GetJsonParameter", ex, request);
            }

            return jsonParameter;
        }
    }
}