using Gbi.Payment.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gbi.Payment.SDK
{
    /// <summary>
    /// Class AliWebPayment.
    /// </summary>
    class AliWebPayment : BaseAliPayment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAliPayment" /> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public AliWebPayment(TransactionInfo config)
            : base(config)
        { }

        /// <summary>
        /// Executes the transaction.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>System.String.</returns>
        public override string CreateTransactionRequest(ITradingOrder order)
        {
            var request = GenerateBasicRequestParameters();

            request.Add(AliServiceConfig.partner, this.TransactionInfo.Partner);
            request.Add(AliServiceConfig.service, AliServiceConfig.AliWebExecuteTransactionService);
            request.Add(AliServiceConfig.PaymentType, ((int)order.PaymentInfo.PaymentType).ToString());
            request.Add(AliServiceConfig.notify_url, this.TransactionInfo.NotifyUrl);
            request.Add(AliServiceConfig.return_url, this.TransactionInfo.CallBackUrl);
            request.Add(AliServiceConfig.seller_email, this.TransactionInfo.SellerAccountName);
            request.Add(AliServiceConfig.out_trade_no, order.Key.ToString());
            request.Add(AliServiceConfig.subject, order.Subject);
            request.Add(AliServiceConfig.total_fee, order.TotalFee.ToString());
            request.Add(AliServiceConfig.body, order.PromotionDescription);
            request.Add(AliServiceConfig.exter_invoke_ip, order.ClientIp);

            return CreateTransactionDataRequest(this.SignRequestData(request)); ;
        }
    }
}
