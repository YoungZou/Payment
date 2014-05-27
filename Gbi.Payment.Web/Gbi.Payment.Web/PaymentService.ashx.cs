using Gbi.Payment.Contract;
using Gbi.Payment.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gbi.Payment.Web
{
    /// <summary>
    /// Class PaymentService.
    /// </summary>
    public class PaymentService : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

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
        private static TransactionInfo CreateDefaultTransactionInfo()
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
    }
}