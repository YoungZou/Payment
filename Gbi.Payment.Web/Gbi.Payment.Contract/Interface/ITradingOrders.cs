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
        /// Gets or sets the type of the logistics.
        /// </summary>
        /// <value>The type of the logistics.</value>
        string LogisticsType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the logistics fee.
        /// </summary>
        /// <value>The logistics fee.</value>
        decimal LogisticsFee
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
        /// Gets or sets the type of the payment.
        /// </summary>
        /// <value>The type of the payment.</value>
        PaymentType PaymentType
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
    }
}
