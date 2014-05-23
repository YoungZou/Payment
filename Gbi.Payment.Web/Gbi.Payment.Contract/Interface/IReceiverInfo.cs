using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The Model namespace.
/// </summary>
namespace Gbi.Payment.Contract
{
    /// <summary>
    /// Interface IReceiverInfo
    /// </summary>
    interface IReceiverInfo
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the address province.
        /// </summary>
        /// <value>The address province.</value>
        string AddressProvince { get; set; }

        /// <summary>
        /// Gets or sets the address city.
        /// </summary>
        /// <value>The address city.</value>
        string AddressCity { get; set; }

        /// <summary>
        /// Gets or sets the address area.
        /// </summary>
        /// <value>The address area.</value>
        string AddressArea { get; set; }

        /// <summary>
        /// Gets or sets the address detail.
        /// the detail address, ex: street, house number
        /// </summary>
        /// <value>The address detail.</value>
        string AddressDetail { get; set; }

        /// <summary>
        /// Gets or sets the mobile.
        /// </summary>
        /// <value>The mobile.</value>
        string Cellphone { get; set; }
    }
}
