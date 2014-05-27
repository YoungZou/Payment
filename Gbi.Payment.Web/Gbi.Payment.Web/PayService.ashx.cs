using Gbi.Common;
using Gbi.Payment.Contract;
using Gbi.Payment.Core;
using Gbi.Payment.SDK;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Gbi.Payment.Web
{
    /// <summary>
    /// Class PaymentService.
    /// </summary>
    public class PayService : BasicService, IHttpHandler
    {
        /// <summary>
        /// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler" /> interface.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpContext" /> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.</param>
        public override void ProcessRequest(HttpContext context)
        {
            string transactionRequest = null;

            try
            {
                string jsonParameter = GetJsonParameter(context.Request);

                ITradingOrder requestObject = (ITradingOrder)JsonConvert.DeserializeObject(jsonParameter, typeof(ITradingOrder));

                PaymentClient client = new PaymentClient(this.TransactionInfo);

                var service = new PaymentService();

                if (requestObject != null)
                {
                    transactionRequest = client.CreateTransactionRequest(requestObject);
                }
            }
            catch (Exception ex)
            {
                transactionRequest = ex.Message.ToString();
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(transactionRequest);
        }
    }
}