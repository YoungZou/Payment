using Gbi.Payment.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gbi.Payment.SDK
{
    class PaypalPayment : BaseAliPayment
    {
        public PaypalPayment(TransactionInfo config)
            : base(config)
        { }

        public override string CreateTransactionRequest(ITradingOrder order)
        {
            throw new NotImplementedException();
        }
    }
}
