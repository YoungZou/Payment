using Gbi.Payment.Contract;
using Gbi.Payment.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gbi.Payment.Core
{
    public class PaymentService : PaymentClient
    {
        public PaymentService(TransactionInfo config)
            : base(config)
        { }

        public PaymentService()
            : base(new TransactionInfo()
            {
            })
        { }

        public override string CreateTransactionRequest(ITradingOrder order)
        {
            #region 

            //TODO: insert order into DB

            #endregion

            return base.CreateTransactionRequest(order);
        }

        public override string GetAuthenticateToken(ITradingOrder order)
        {
            return base.GetAuthenticateToken(order);
        }
    }
}
