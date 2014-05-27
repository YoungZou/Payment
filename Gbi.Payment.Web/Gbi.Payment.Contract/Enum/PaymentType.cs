using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Gbi.Payment.Contract
{
    /// <summary>
    /// Enum PaymentType
    /// </summary>
    [DataContract]
    public enum PaymentType
    {
        /// <summary>
        /// The buying
        /// </summary>
        [EnumMember]
        Buying = 1,

        /// <summary>
        /// The donation
        /// </summary>
        [EnumMember]
        Donation = 4,

        /// <summary>
        /// The electronic card voucher
        /// </summary>
        [EnumMember]
        ElectronicCardVoucher = 47
    }

    /// <summary>
    /// Enum PayUnit
    /// </summary>
    [DataContract]
    public enum PayCurrency
    {
        USD,

        RMB
    }

    /// <summary>
    /// Enum PaymentMethod
    /// </summary>
    [DataContract]
    public enum PaymentMethod
    {
        [EnumMember]
        creditPay,

        [EnumMember]
        directPay
    }
}
