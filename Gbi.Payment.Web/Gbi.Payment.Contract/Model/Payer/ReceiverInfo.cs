using Gbi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Gbi.Payment.Contract
{
    /// <summary>
    /// Class ReceiverInfo.
    /// </summary>
   [DataContract]
    public class ReceiverInfo : BaseObject, IReceiverInfo
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember]
       public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the address province.
        /// </summary>
        /// <value>The address province.</value>
        [DataMember]
        public string AddressProvince
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the address city.
        /// </summary>
        /// <value>The address city.</value>
        [DataMember]
        public string AddressCity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the address area.
        /// </summary>
        /// <value>The address area.</value>
        [DataMember]
        public string AddressArea
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the address detail.
        /// the detail address, ex: street, house number
        /// </summary>
        /// <value>The address detail.</value>
        [DataMember]
        public string AddressDetail
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the cellphone.
        /// </summary>
        /// <value>The cellphone.</value>
        [DataMember]
        public string Cellphone
        {
            get;
            set;
        }
    }
}
