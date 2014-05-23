using Gbi.Payment.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gbi.Payment.SDK
{
    /// <summary>
    /// Class AliMobilePayment.
    /// </summary>
    class AliMobilePayment : BaseAliPayment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAliPayment" /> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public AliMobilePayment(TransactionInfo config)
            : base(config)
        { }

        /// <summary>
        /// Gets the authorization token.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>System.String.</returns>
        public override string GetAuthenticateToken(ITradingOrder order)
        {
            var request = GenerateBasicRequestParameters();

            request.Add(AliServiceConfig.partner, this.TransactionInfo.Partner);
            request.Add(AliServiceConfig.format, AliServiceConfig.Format);
            request.Add(AliServiceConfig.version, AliServiceConfig.Version);
            request.Add(AliServiceConfig.sec_id, AliServiceConfig.SignType.ToUpper());
            request.Add(AliServiceConfig.req_id, AliServiceConfig.RequestId);
            request.Add(AliServiceConfig.service, AliServiceConfig.AliCellphoneCreateTokenService);
            request.Add(AliServiceConfig.req_data,
                string.Format(AliServiceConfig.RequestDataToken,
                /// {0}: notify_url
                /// {1}: call_back_url
                /// {2}: seller_account_name
                /// {3}: trade number
                /// {4}: trade subject
                /// {5}: total fee
                /// {6}: merchant_url
                this.TransactionInfo.NotifyUrl,
                this.TransactionInfo.CallBackUrl,
                this.TransactionInfo.SellerAccountName,
                order.Key,
                order.Subject,
                order.TotalFee
                ));

            return GetAuthenticateToken(SignRequestData(request));
        }

        /// <summary>
        /// Executes the transaction.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>System.String.</returns>
        public override string ExecuteTransaction(ITradingOrder order)
        {
            string token = this.GetAuthenticateToken(order);

            var request = GenerateBasicRequestParameters();

            request.Add(AliServiceConfig.partner, this.TransactionInfo.Partner);
            request.Add(AliServiceConfig.service, AliServiceConfig.AliCellphoneExecuteTransactionService);
            request.Add(AliServiceConfig.sec_id, AliServiceConfig.SignType.ToUpper());
            request.Add(AliServiceConfig.format, AliServiceConfig.Format);
            request.Add(AliServiceConfig.version, AliServiceConfig.Version);
            request.Add(AliServiceConfig.req_data, string.Format(AliServiceConfig.RequestTransactionData, token));

            return CreateTransactionDataRequest(SignRequestData(request));
        }
    }
}
