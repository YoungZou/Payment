using Gbi.Payment.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gbi.Payment.Core
{
    /// <summary>
    /// Class PaymentServiceCore.
    /// </summary>
    public class PaymentServiceCore
    {
        /// <summary>
        /// Creates the trading order.
        /// </summary>
        /// <param name="order">The order.</param>
        public void CreateTradingOrder(ITradingOrder order)
        {
            try
            {
                using (var controller = new TradingOrderAccessController())
                {
                    controller.CreateTradingOrder(order);
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Updates the trading order state by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="status">The status.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool UpdateTradingOrderStateByKey(Guid key, TradingOrderStatus status)
        {
            try
            {
                using (var controller = new TradingOrderAccessController())
                {
                    return controller.UpdateTradingOrderStateByKey(key, status);
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
