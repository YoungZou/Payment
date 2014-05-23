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
    /// Interface IProductItem
    /// </summary>
    public interface IProductItem
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        Guid? Key { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the total quantity.
        /// </summary>
        /// <value>The total quantity.</value>
        int TotalQuantity { get; set; }

        /// <summary>
        /// Gets or sets the detail URL.
        /// </summary>
        /// <value>The detail URL.</value>
        string DetailUrl { get; set; }

        /// <summary>
        /// Gets or sets the picture URL.
        /// </summary>
        /// <value>The picture URL.</value>
        string PictureUrl { get; set; }
    }
}
