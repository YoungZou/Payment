using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Gbi.Payment.Contract
{
    /// <summary>
    /// Class TradeItem.
    /// </summary>
    [DataContract]
    public class TradeItem : ProductItem, ITradeItem
    {
        /// <summary>
        /// Gets or sets the purchase quantity.
        /// </summary>
        /// <value>The purchase quantity.</value>
        [DataMember]
        public int PurchaseQuantity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the total price.
        /// </summary>
        /// <value>The total price.</value>
        [DataMember]
        public decimal TotalPrice
        {
            get;
            set;
        }

        public TradeItem()
        {
        }

        public TradeItem(IProductItem productItem, int purchaseQuantity, decimal totalPrice)
            : this()
        {
            //Todo
            this.PurchaseQuantity = purchaseQuantity;
            this.TotalPrice = totalPrice;

        }
    }
}
