﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Gbi.Payment.Contract
{
    /// <summary>
    /// Enum TransactionType
    /// </summary>
    [DataContract]
    public enum TransactionType
    {
        /// <summary>
        /// The ali web payment
        /// </summary>
        [EnumMember]
        AliWebPayment,

        /// <summary>
        /// The ali mobile payment
        /// </summary>
        [EnumMember]
        AliMobilePayment,

        /// <summary>
        /// The paypal payment
        /// </summary>
        [EnumMember]
        PaypalPayment
    }
}
