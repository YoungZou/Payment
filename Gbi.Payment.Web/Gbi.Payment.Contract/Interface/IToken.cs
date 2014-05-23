using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Gbi.Payment.Contract
{
    /// <summary>
    /// Interface IToken
    /// </summary>
    [ServiceContract]
    public interface IToken
    {
        /// <summary>
        /// Gets the authenticate token.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>System.String.</returns>
        [OperationContract]
        string GetAuthenticateToken(ITradingOrder order);
    }
}
