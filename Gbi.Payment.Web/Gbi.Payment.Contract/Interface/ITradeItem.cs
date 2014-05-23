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
    /// Interface ITradeItem
    /// </summary>
    public interface ITradeItem : IProductItem
    {
        /// <summary>
        /// Gets the purchase quantity.
        /// </summary>
        /// <value>The purchase quantity.</value>
        int PurchaseQuantity
        {
            get;
        }

        /// <summary>
        /// Gets the total price.
        /// </summary>
        /// <value>The total price.</value>
        decimal TotalPrice
        {
            get;
        }
    }
}
