using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gbi.Payment.Contract
{
    /// <summary>
    /// Enum TransactionType
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        /// The ali web payment
        /// </summary>
        AliWebPayment,

        /// <summary>
        /// The ali mobile payment
        /// </summary>
        AliMobilePayment,

        /// <summary>
        /// The paypal payment
        /// </summary>
        PaypalPayment
    }
}
