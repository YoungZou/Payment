using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Gbi.Payment.Contract
{
    /// <summary>
    /// Enum TradingOrderStatus
    /// </summary>
    [DataContract]
    public enum TradingOrderStatus
    {
        /// <summary>
        /// The pending
        /// </summary>
        [EnumMember]
        Pending = 0,

        /// <summary>
        /// The failed
        /// </summary>
        [EnumMember]
        Failed = 1,

        /// <summary>
        /// The finished
        /// </summary>
        [EnumMember]
        Finished = 2,

        /// <summary>
        /// The Succeed
        /// this status only occurred when has the advanced realthime pay function
        /// </summary>
        [EnumMember]
        Succeed = 3    
    }
}
