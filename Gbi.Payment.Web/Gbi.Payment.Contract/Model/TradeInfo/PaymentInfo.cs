using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Gbi.Payment.Contract
{
    /// <summary>
    /// Class PaymentInfo.
    /// </summary>
    [DataContract]
    public class PaymentInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentInfo"/> class.
        /// </summary>
        public PaymentInfo()
        {
            this.PaymentType = PaymentType.Buying;
            this.PaymentMethod = PaymentMethod.directPay;
            this.IsCTUCheck = false;
        }

        /// <summary>
        /// Gets or sets the type of the payment.
        /// </summary>
        /// <value>The type of the payment.</value>
        [DataMember]
        public PaymentType PaymentType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the pay method.
        /// </summary>
        /// <value>The pay method.</value>
        [DataMember]
        public PaymentMethod PaymentMethod
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is ctu check.
        /// </summary>
        /// <value><c>true</c> if this instance is ctu check; otherwise, <c>false</c>.</value>
        [DataMember]
        public bool IsCTUCheck
        {
            get;
            set;
        }
    }
}
