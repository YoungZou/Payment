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
    /// Class TradingOrders.
    /// </summary>
    [DataContract]
    public class TradingOrders : BaseObject, ITradingOrder
    {
        /// <summary>
        /// Gets or sets the subject.
        /// order subject
        /// </summary>
        /// <value>The subject.</value>
        [DataMember]
        public string Subject
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the total fee.
        /// </summary>
        /// <value>The total fee.</value>
        [DataMember]
        public decimal TotalFee
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the logistics.
        /// </summary>
        /// <value>The type of the logistics.</value>
        [DataMember]
        public string LogisticsType
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

        /// <summary>
        /// Gets or sets the promotion description.
        /// </summary>
        /// <value>The promotion description.</value>
        [DataMember]
        public string PromotionDescription
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [DataMember]
        public List<ITradeItem> Items
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the receiver.
        /// </summary>
        /// <value>The receiver.</value>
        [DataMember]
        public ReceiverInfo Receiver
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the client ip.
        /// </summary>
        /// <value>The client ip.</value>
        [DataMember]
        public string ClientIp
        {
            get;
            set;
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
    }
}
