using Gbi.Common;
using Gbi.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Gbi.Payment.Contract
{
    /// <summary>
    /// interface ITradingOrders.
    /// stores the trade infos,
    /// ex: trade id, subject, total fee ...
    /// </summary>
    public interface ITradingOrder : IBaseObject
    {
        /// <summary>
        /// Gets or sets the ali trade number.
        /// </summary>
        /// <value>The ali trade number.</value>
       string AliTradeNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the subject.
        /// order subject
        /// </summary>
        /// <value>The subject.</value>
        string Subject
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the total fee.
        /// </summary>
        /// <value>The total fee.</value>
        decimal TotalFee
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the promotion description.
        /// </summary>
        /// <value>The promotion description.</value>
        string PromotionDescription
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the client ip.
        /// </summary>
        /// <value>The client ip.</value>
        string ClientIp
        {
            get;
            set;
        }  

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        List<ITradeItem> Items
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the receiver.
        /// </summary>
        /// <value>The receiver.</value>
        ReceiverInfo Receiver
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the payment information.
        /// </summary>
        /// <value>The payment information.</value>
        PaymentInfo PaymentInfo
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the logistics information.
        /// </summary>
        /// <value>The logistics information.</value>
        LogisticsInfo LogisticsInfo
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        TradingOrderStatus Status
        {
            get;
            set;
        }
    }
}
