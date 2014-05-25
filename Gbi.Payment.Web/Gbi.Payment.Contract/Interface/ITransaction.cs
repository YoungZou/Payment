using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace Gbi.Payment.Contract
{
    /// <summary>
    /// Interface ITransaction
    /// </summary>
    [ServiceContract]
    public interface ITransaction 
    {
        /// <summary>
        /// Creates the transaction request.  
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>System.String.</returns>
        [OperationContract]
        string CreateTransactionRequest(ITradingOrder order);
    }
}
