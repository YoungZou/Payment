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
    public class TradingOrder : BaseObject, ITradingOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TradingOrder"/> class.
        /// </summary>
        public TradingOrder()
        {
            this.PaymentInfo = new PaymentInfo();
            this.LogisticsInfo = new LogisticsInfo();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TradingOrder"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="receiver">The receiver.</param>
        public TradingOrder(List<ITradeItem> item, ReceiverInfo receiver)
            : this()
        {
            this.Items = item;
            this.Receiver = receiver;
        }

        /// <summary>
        /// Gets or sets the ali trade number.
        /// </summary>
        /// <value>The ali trade number.</value>
        [DataMember]
        public string AliTradeNumber
        {
            get;
            set;
        }

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
        /// Gets or sets the payment information.
        /// </summary>
        /// <value>The payment information.</value>
        [DataMember]
        public PaymentInfo PaymentInfo
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the logistics information.
        /// </summary>
        /// <value>The logistics information.</value>
        [DataMember]
        public LogisticsInfo LogisticsInfo
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [DataMember]
        public TradingOrderStatus Status
        {
            get;
            set;
        }
    }
}
