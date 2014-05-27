using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gbi.Payment.SDK
{
    public static class WebExtension
    {
        /// <summary>
        /// Gets the HTTP response string.
        /// default timeout is 120000
        /// </summary>
        /// <param name="strUrl">The string URL.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>System.String.</returns>
        public static string GetHttpResponseString(this string strUrl, int timeout = 120000)
        {
            string strResult = "";

            try
            {
                HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(strUrl);
                myReq.Timeout = timeout;
                HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
                Stream myStream = HttpWResp.GetResponseStream();
                StreamReader sr = new StreamReader(myStream, Encoding.Default);
                StringBuilder strBuilder = new StringBuilder();
                while (-1 != sr.Peek())
                {
                    strBuilder.Append(sr.ReadLine());
                }

                strResult = strBuilder.ToString();
            }
            catch (Exception exp)
            {
                strResult = "ERROR：" + exp.Message;
            }

            return strResult;
        }
    }
}
