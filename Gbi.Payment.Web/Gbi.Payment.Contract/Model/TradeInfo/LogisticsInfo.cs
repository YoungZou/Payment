using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Gbi.Payment.Contract
{
    /// <summary>
    /// Class LogisticsInfo.
    /// </summary>
    [DataContract]
    public class LogisticsInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogisticsInfo"/> class.
        /// </summary>
        public LogisticsInfo()
        {
            this.LogisticsType = LogisticsType.post;
        }

        /// <summary>
        /// Gets or sets the type of the logistics.
        /// default is LogisticsType.post
        /// </summary>
        /// <value>The type of the logistics.</value>
        [DataMember]
        public LogisticsType LogisticsType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the logistics fee.
        /// </summary>
        /// <value>The logistics fee.</value>
        [DataMember]
        public decimal LogisticsFee
        {
            get;
            set;
        }
    }
}
