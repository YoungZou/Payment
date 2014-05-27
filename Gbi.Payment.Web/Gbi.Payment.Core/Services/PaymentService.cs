using Gbi.Payment.Contract;
using Gbi.Payment.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gbi.Payment.Core
{
    /// <summary>
    /// Class PaymentService.
    /// </summary>
    public class PaymentService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentService"/> class.
        /// </summary>
        public PaymentService()
        { }

        /// <summary>
        /// Creates the trading order.
        /// </summary>
        /// <param name="order">The order.</param>
        public void CreateTradingOrder(ITradingOrder order)
        {
            try
            {
                var serviceCore = new PaymentServiceCore();
                serviceCore.CreateTradingOrder(order);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Updates the state of the trading order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool UpdateTradingOrderState(Guid key, TradingOrderStatus status)
        {
            try
            {
                var serviceCore = new PaymentServiceCore();
                return serviceCore.UpdateTradingOrderStateByKey(key, status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
