using Gbi.Payment.Contract;
using Gbi.Service.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gbi.Payment.Core
{
    /// <summary>
    /// Class TradingOrderAccessController.
    /// </summary>
    public class TradingOrderAccessController : SqlDataAccessController<ITradingOrder>
    {
        #region properties

        /// <summary>
        /// The column_ subject
        /// </summary>
        const string column_Subject = "Subject";

        /// <summary>
        /// The column_ total fee
        /// </summary>
        const string column_TotalFee = "TotalFee";

        /// <summary>
        /// The column_ promotion description
        /// </summary>
        const string column_PromotionDescription = "PromotionDescription";

        /// <summary>
        /// The column_ client ip
        /// </summary>
        const string column_ClientIp = "ClientIp";

        /// <summary>
        /// The column_ product item key
        /// </summary>
        const string column_ProductItemKey = "ProductItemKey";

        /// <summary>
        /// The column_ receiver key
        /// </summary>
        const string column_ReceiverKey = "ReceiverKey";

        /// <summary>
        /// The column_ payment type
        /// </summary>
        const string column_PaymentType = "PaymentType";

        /// <summary>
        /// The column_ payment method
        /// </summary>
        const string column_PaymentMethod = "PaymentMethod";

        /// <summary>
        /// The column_ logistics type
        /// </summary>
        const string column_LogisticsType = "LogisticsType";

        /// <summary>
        /// The column_ logistics fee
        /// </summary>
        const string column_LogisticsFee = "LogisticsFee";

        /// <summary>
        /// The column_ status
        /// </summary>
        const string column_Status = "Status";

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TradingOrderAccessController"/> class.
        /// </summary>
        public TradingOrderAccessController()
            : base(Framework.SqlConnection)
        { }

        /// <summary>
        /// Converts the entity object.
        /// </summary>
        /// <param name="sqlDataReader">The SQL data reader.</param>
        /// <returns>ITradingOrder.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override ITradingOrder ConvertEntityObject(System.Data.SqlClient.SqlDataReader sqlDataReader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates the trading order.
        /// </summary>
        /// <param name="order">The order.</param>
        public void CreateTradingOrder(ITradingOrder order)
        {
            const string spName = "sp_CreateTradingOrder";
            order.CheckNullObject("ITradingOrder");

            try
            {
                string productIds = "";

                foreach (var item in order.Items)
                {
                    productIds = "<Key>" + item.Key + "</Key>";
                }

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(GenerateSqlSpParameter(column_Key, order.Key));
                parameters.Add(GenerateSqlSpParameter(column_Subject, order.Subject));
                parameters.Add(GenerateSqlSpParameter(column_TotalFee, order.TotalFee));
                parameters.Add(GenerateSqlSpParameter(column_PromotionDescription, order.PromotionDescription));
                parameters.Add(GenerateSqlSpParameter(column_ClientIp, order.ClientIp));
                parameters.Add(GenerateSqlSpParameter(column_ProductItemKey, string.Format("<ProductItems>{0}</ProductItems>", productIds)));
                parameters.Add(GenerateSqlSpParameter(column_ReceiverKey, order.Receiver.Key));
                parameters.Add(GenerateSqlSpParameter(column_PaymentType, order.PaymentInfo.PaymentType));
                parameters.Add(GenerateSqlSpParameter(column_PaymentMethod, order.PaymentInfo.PaymentMethod));
                parameters.Add(GenerateSqlSpParameter(column_LogisticsType, order.LogisticsInfo.LogisticsType));
                parameters.Add(GenerateSqlSpParameter(column_LogisticsFee, order.LogisticsInfo.LogisticsFee));
                parameters.Add(GenerateSqlSpParameter(column_CreatedStamp, order.CreatedStamp));
                parameters.Add(GenerateSqlSpParameter(column_LastUpdatedStamp, order.LastUpdatedStamp));
                parameters.Add(GenerateSqlSpParameter(column_Status, order.Status));

                databaseOperator.ExecuteNonQuery(spName, parameters);
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
        public bool UpdateTradingOrderStateByKey(Guid key, string status)
        {
            const string spName = "sp_UpdateTradingOrderStateByKey";
            key.CheckNullObject("key");

            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(GenerateSqlSpParameter(column_Key, key));
                parameters.Add(GenerateSqlSpParameter(column_Status, status));

                return databaseOperator.ExecuteNonQuery(spName, parameters).DBToBoolean();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ITradingOrder> GetTradingOrder()
        {
            // TODO
            return null;
        }
    }
}
