using Gbi.Payment.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Gbi.Payment.SDK
{
    /// <summary>
    /// Class BaseAliPayment.
    /// </summary>
    abstract class BaseAliPayment : IToken, ITransaction
    {
        /// <summary>
        /// The configuration
        /// </summary>
        protected TransactionInfo TransactionInfo = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAliPayment"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public BaseAliPayment(TransactionInfo config)
        {
            this.TransactionInfo = config;
        }

        /// <summary>
        /// Gets the authorization token.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>System.String.</returns>
        public virtual string GetAuthenticateToken(ITradingOrder order)
        {
            return string.Empty;
        }

        /// <summary>
        /// Executes the transaction.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>System.String.</returns>
        public abstract string ExecuteTransaction(ITradingOrder order);

        /// <summary>
        /// Signs the request data.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>Dictionary{System.StringSystem.String}.</returns>
        protected Dictionary<string, string> SignRequestData(SortedDictionary<string, string> toBeSignedData)
        {
            var result = new Dictionary<string, string>();
            result = FilterDictionary(toBeSignedData);

            string preSignedStr = result.ToKeyValueString();

            // sign string
            string signed = MD5Sign(preSignedStr, this.TransactionInfo.Key);

            if (!string.IsNullOrEmpty(signed))
            {
                // add signed to result
                result.Add(AliServiceConfig.Sign, signed);
            }

            if (result[AliServiceConfig.service] != AliServiceConfig.AliCellphoneCreateTokenService && result[AliServiceConfig.service] != AliServiceConfig.AliCellphoneExecuteTransactionService)
            {
                result.Add(AliServiceConfig.sign_type, AliServiceConfig.SignType);
            }

            return result;
        }

        /// <summary>
        /// Creates the transaction data request.
        /// </summary>
        /// <param name="dic">The dictionary.</param>
        /// <returns>System.String.</returns>
        protected static string CreateTransactionDataRequest(Dictionary<string, string> dic)
        {
            StringBuilder sbHtml = new StringBuilder();

            sbHtml.Append("<form id='alipaysubmit' name='alipaysubmit' action='" + AliServiceConfig.AliCellphoneGateway + "' method='get'>");

            if (dic != null && dic.Count > 0)
            {
                foreach (KeyValuePair<string, string> temp in dic)
                {
                    sbHtml.Append("<input type='hidden' name='" + temp.Key + "' value='" + temp.Value + "'/>");
                }
            }

            //submit按钮控件请不要含有name属性
            sbHtml.Append("<input type='submit' value='Submit' style='display:none;'></form>");

            sbHtml.Append("<script>document.forms['alipaysubmit'].submit();</script>");

            return sbHtml.ToString();
        }

        /// <summary>
        /// Generates the basic request parameters.
        /// </summary>
        /// <returns>SortedDictionary{System.StringSystem.String}.</returns>
        protected static SortedDictionary<string, string> GenerateBasicRequestParameters()
        {
            var parameters = new SortedDictionary<string, string>();

            parameters.Add(AliServiceConfig.input_charset, AliServiceConfig.InputCharset.ToLower());

            return parameters;
        }

        /// <summary>
        /// Filters the specified automatic be filtered.
        /// </summary>
        /// <param name="toBeFiltered">The automatic be filtered.</param>
        /// <returns>Dictionary{System.StringSystem.String}.</returns>
        protected static Dictionary<string, string> FilterDictionary(SortedDictionary<string, string> toBeFiltered)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> temp in toBeFiltered)
            {
                if (temp.Key.ToLower() != "sign" && temp.Key.ToLower() != "sign_type" && !string.IsNullOrEmpty(temp.Value))
                {
                    result.Add(temp.Key, temp.Value);
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the authenticate token.
        /// </summary>
        /// <param name="requestData">The request data.</param>
        /// <param name="gateway">The gateway.</param>
        /// <param name="charSet">The character set.</param>
        /// <returns>System.String.</returns>
        public static string GetAuthenticateToken(Dictionary<string, string> requestData, string gateway = null, Encoding charSet = null)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            try
            {
                string[] response = Post(requestData, gateway, charSet).Split('&');

                if (response != null && response.Length > 0)
                {
                    for (int i = 0; i < response.Length; i++)
                    {
                        string[] keyValuePair = response[i].Split('=');

                        result.Add(keyValuePair[0], keyValuePair[1]);
                    }
                }

                if (result["res_data"] != null)
                {
                    // token from res_data
                    XmlDocument xmlDoc = new XmlDocument();

                    xmlDoc.LoadXml(result["res_data"]);

                    return xmlDoc.SelectSingleNode("/direct_trade_create_res/request_token").InnerText;
                }
            }

            catch (Exception exp)
            {
                return exp.ToString();
            }

            return string.Empty;
        }

        /// <summary>
        /// Commands the d5 sign.
        /// </summary>
        /// <param name="preSign">The preference sign.</param>
        /// <param name="key">The key.</param>
        /// <param name="charsetSet">The charset set.</param>
        /// <returns>System.String.</returns>
        protected static string MD5Sign(string preSign, string key, string charsetSet = null)
        {
            if (charsetSet == null)
            {
                charsetSet = AliServiceConfig.InputCharset;
            }

            StringBuilder stringBuilder = new StringBuilder(32);

            if (!string.IsNullOrEmpty(preSign) && !string.IsNullOrEmpty(key))
            {
                preSign = preSign + key;
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] t = md5.ComputeHash(Encoding.GetEncoding(charsetSet).GetBytes(preSign));

                for (int i = 0; i < t.Length; i++)
                {
                    stringBuilder.Append(t[i].ToString("x").PadLeft(2, '0'));
                }
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Posts the specified request data.
        /// </summary>
        /// <param name="requestData">The request data.</param>
        /// <param name="gateway">The gateway.</param>
        /// <param name="charSet">The character set.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception"></exception>
        private static string Post(Dictionary<string, string> requestData, string gateway = null, Encoding charSet = null)
        {
            if (gateway == null)
            {
                gateway = AliServiceConfig.AliCellphoneGateway;
            }

            if (charSet == null)
            {
                charSet = Encoding.GetEncoding(AliServiceConfig.InputCharset);
            }

            WebResponse response = null;

            try
            {
                HttpWebRequest request = gateway.CreateHttpWebRequest(gateway);
                request.FillData("POST", requestData, charSet);

                response = request.GetResponse();

                return response.ReadAsText(charSet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
        }
    }
}