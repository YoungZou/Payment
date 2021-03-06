﻿using Gbi.Payment.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gbi.Payment.SDK
{
    /// <summary>
    /// Class PaymentClient.
    /// </summary>
    public class PaymentClient
    {
        /// <summary>
        /// The payment
        /// </summary>
        BaseAliPayment Payment = null;
  
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentClient" /> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public PaymentClient(TransactionInfo config)
        {
            switch (config.Type)
            {
                case TransactionType.AliWebPayment:
                    this.Payment = new AliWebPayment(config);
                    break;
                case TransactionType.AliMobilePayment:
                    this.Payment = new AliMobilePayment(config);
                    break;
                case TransactionType.PaypalPayment:
                    this.Payment = new PaypalPayment(config);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Create the transaction request.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>System.String.</returns>
        public string CreateTransactionRequest(ITradingOrder order)
        {
            if(Payment !=null)
            {
                return Payment.CreateTransactionRequest(order);
            }
            return string.Empty;
        }

        /// <summary>
        /// Gets the authenticate token.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>System.String.</returns>
        public string GetAuthenticateToken(ITradingOrder order)
        {
            if (Payment != null)
            {
                return Payment.GetAuthenticateToken(order);
            }
            return string.Empty;
        }

        /// <summary>
        /// Gets the signed string.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns>System.String.</returns>
        public string GetSignedString(Dictionary<string, string> dictionary)
        {
            if (Payment != null)
            {
                return Payment.GetSignedString(dictionary);
            }
            return string.Empty;
        }
    }
}
