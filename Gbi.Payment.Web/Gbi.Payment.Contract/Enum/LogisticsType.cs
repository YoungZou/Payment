using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Gbi.Payment.Contract
{
    /// <summary>
    /// Enum LogisticsType
    /// </summary>
    [DataContract]
    public enum LogisticsType
    {
        [EnumMember]
        post,

        [EnumMember]
        express
    }
}
