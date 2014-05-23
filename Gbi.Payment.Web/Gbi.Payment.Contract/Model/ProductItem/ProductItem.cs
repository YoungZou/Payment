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
    /// Class Item.
    /// </summary>
    [DataContract]
    public class ProductItem : BaseObject, IProductItem
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
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [DataMember]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [DataMember]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        [DataMember]
        public decimal Price
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the total quantity.
        /// </summary>
        /// <value>The total quantity.</value>
        [DataMember]
        public int TotalQuantity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the detail URL.
        /// </summary>
        /// <value>The detail URL.</value>
        [DataMember]
        public string DetailUrl
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the picture URL.
        /// </summary>
        /// <value>The picture URL.</value>
        [DataMember]
        public string PictureUrl
        {
            get;
            set;
        }
    }
}
