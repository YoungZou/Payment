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
        /// Executes the transaction.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>System.String.</returns>
        [OperationContract]
        string ExecuteTransaction(ITradingOrder order);
    }
}
