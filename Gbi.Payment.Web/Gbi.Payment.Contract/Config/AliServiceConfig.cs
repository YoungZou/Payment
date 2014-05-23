using Gbi.Service.Common;
using Gbi.Service.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gbi.Payment.Contract
{
    /// <summary>
    /// Class AlipayRequestConfig.
    /// </summary>
    public static class AliServiceConfig
    {
        /// <summary>
        /// The notify_url
        /// </summary>
        public const string notify_url = "notify_url";

        /// <summary>
        /// The call_back_url
        /// </summary>
        public const string call_back_url = "call_back_url";

        /// <summary>
        /// The return_url
        /// </summary>
        public const string return_url = "return_url";

        /// <summary>
        /// The out_trade_no
        /// </summary>
        public const string out_trade_no = "out_trade_no";

        /// <summary>
        /// The subject
        /// </summary>
        public const string subject = "subject";

        /// <summary>
        /// The total_fee
        /// </summary>
        public const string total_fee = "total_fee";

        /// <summary>
        /// The body
        /// </summary>
        public const string body = "body";

        /// <summary>
        /// The show_url
        /// </summary>
        public const string show_url = "show_url";

        /// <summary>
        /// The exter_invoke_ip
        /// </summary>
        public const string exter_invoke_ip = "exter_invoke_ip";

        /// <summary>
        /// The merchant_url
        /// </summary>
        public const string merchant_url = "merchant_url";

        /// <summary>
        /// The seller_email
        /// </summary>
        public const string seller_email = "seller_email";

        /// <summary>
        /// The partner
        /// </summary>
        public const string partner = "partner";

        /// <summary>
        /// The input_charset
        /// </summary>
        public const string input_charset = "_input_charset";

        /// <summary>
        /// The sec_id
        /// </summary>
        public const string sign_type = "sign_type";

        // <summary>
        /// <summary>
        /// The sec_id
        /// </summary>
        public const string sec_id = "sec_id";

        /// <summary>
        /// The service
        /// </summary>
        public const string service = "service";

        /// <summary>
        /// The format
        /// </summary>
        public const string format = "format";

        /// <summary>
        /// The average
        /// </summary>
        public const string version = "v";

        /// <summary>
        /// The req_id
        /// request id, should be unique for every request
        /// </summary>
        public const string req_id = "req_id";

        /// <summary>
        /// The request data token
        /// request with basic and trade info
        /// </summary>
        public const string req_data = "req_data";

        /// <summary>
        /// Gets the type of the sign.
        /// </summary>
        /// <value>The type of the sign.</value>
        public const string SignType = "MD5";

        /// <summary>
        /// The payment type
        /// </summary>
        public const string PaymentType = "payment_type";

        /// <summary>
        /// The ali cellphone create token service
        /// </summary>
        public const string AliCellphoneCreateTokenService = "alipay.wap.trade.create.direct";

        /// <summary>
        /// The ali cellphone execute transaction service
        /// </summary>
        public const string AliCellphoneExecuteTransactionService = "alipay.wap.auth.authAndExecute";

        /// <summary>
        /// The ali web execute transaction service
        /// </summary>
        public const string AliWebExecuteTransactionService = "create_direct_pay_by_user";

        /// <summary>
        /// The key
        /// </summary>
        public const string key = "key";

        /// <summary>
        /// Gets the format.
        /// </summary>
        /// <value>The format.</value>
        public const string Format = "xml";
        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>The version.</value>
        public const string Version = "2.0";

        /// <summary>
        /// Gets the input charset.
        /// </summary>
        /// <value>The input charset.</value>
        public const string InputCharset = "utf-8";

        /// <summary>
        /// The sign
        /// </summary>
        public const string Sign = "sign";

        /// <summary>
        /// The req_transaction_data
        /// </summary>
        public const string req_transaction_data = "req_data";

        /// <summary>
        /// Gets the ali gateway.
        /// </summary>
        /// <value>The ali gateway.</value>
        public const string AliCellphoneGateway = "http://wappaygw.alipay.com/service/rest.htm?_input_charset=utf-8";

        /// <summary>
        /// The ali web gateway
        /// </summary>
        public const string AliWebGateway = "https://mapi.alipay.com/gateway.do?_input_charset=utf-8";

        /// <summary>
        /// Gets the request data.
        /// {0}: notify_url
        /// {1}: call_back_url
        /// {2}: seller_account_name
        /// {3}: trade number
        /// {4}: trade subject
        /// {5}: total fee
        /// {6}: merchant_url
        /// </summary>
        /// <value>The request data.</value>
        public static readonly string RequestDataToken = "<direct_trade_create_req><notify_url>{0}</notify_url><call_back_url>{1}</call_back_url><seller_account_name>{2}</seller_account_name><out_trade_no>{3}</out_trade_no><subject>{4}</subject><total_fee>{5}</total_fee><merchant_url>{0}</merchant_url></direct_trade_create_req>";

        /// <summary>
        /// The request transaction data
        /// {0}: request_token
        /// </summary>
        public static readonly string RequestTransactionData = "<auth_and_execute_req><request_token>{0}</request_token></auth_and_execute_req>";

        /// <summary>
        /// Gets the request unique identifier.
        /// </summary>
        /// <value>The request unique identifier.</value>
        public static string RequestId
        {
            get
            {
                return DateTime.Now.ToJavaScriptDateTime().ToString();
            }
        }
    }
}
