using Gbi.Common;
using Gbi.Payment.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Gbi.Payment.Contract
{
    /// <summary>
    /// Class TransactionInfo.
    /// </summary>
    [DataContract]
    public class TransactionInfo
    {
        /// <summary>
        /// Gets or sets the key.
        /// MD5 key from ali account
        /// </summary>
        /// <value>The key.</value>
        [DataMember]
        public string Key
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the seller account.
        /// </summary>
        /// <value>The name of the seller account.</value>
        [DataMember]
        public string SellerAccountName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the partner.
        /// </summary>
        /// <value>The partner.</value>
        [DataMember]
        public string Partner
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type.
        /// this parameter means the transaction type which belongs to, eg: AliWebPayment, AliMobilePayment, PaypalPayment
        /// </summary>
        /// <value>The type.</value>
        [DataMember]
        public TransactionType Type
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the service.
        /// invoking service name
        /// </summary>
        /// <value>The name of the service.</value>
        [DataMember]
        public string ServiceName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the notify URL.
        /// </summary>
        /// <value>The notify URL.</value>
        [DataMember]
        public string NotifyUrl
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the call back URL.
        /// </summary>
        /// <value>The call back URL.</value>
        [DataMember]
        public string CallBackUrl
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the merchant URL.
        /// </summary>
        /// <value>The merchant URL.</value>
        [DataMember]
        public string MerchantUrl
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionInfo"/> class.
        /// </summary>
        public TransactionInfo()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionInfo"/> class.
        /// </summary>
        /// <param name="partner">The partner.</param>
        /// <param name="key">The key.</param>
        /// <param name="sellerAccountName">Name of the seller account.</param>
        public TransactionInfo(string partner, string key, string sellerAccountName)
            : this()
        {
            this.Partner = partner;
            this.Key = key;
            this.SellerAccountName = sellerAccountName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionInfo"/> class.
        /// </summary>
        /// <param name="partner">The partner.</param>
        /// <param name="key">The key.</param>
        /// <param name="sellerAccountName">Name of the seller account.</param>
        /// <param name="notifyUrl">The notify URL.</param>
        public TransactionInfo(string partner, string key, string sellerAccountName, string notifyUrl)
            : this(partner, key, sellerAccountName)
        {
            this.NotifyUrl = notifyUrl;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionInfo"/> class.
        /// </summary>
        /// <param name="partner">The partner.</param>
        /// <param name="key">The key.</param>
        /// <param name="sellerAccountName">Name of the seller account.</param>
        /// <param name="notifyUrl">The notify URL.</param>
        /// <param name="callbackUrl">The callback URL.</param>
        public TransactionInfo(string partner, string key, string sellerAccountName, string notifyUrl, string callbackUrl)
            : this(partner, key, sellerAccountName, notifyUrl)
        {
            this.CallBackUrl = callbackUrl;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionInfo"/> class.
        /// </summary>
        /// <param name="partner">The partner.</param>
        /// <param name="key">The key.</param>
        /// <param name="sellerAccountName">Name of the seller account.</param>
        /// <param name="notifyUrl">The notify URL.</param>
        /// <param name="callbackUrl">The callback URL.</param>
        /// <param name="MerchantUrl">The merchant URL.</param>
        public TransactionInfo(string partner, string key, string sellerAccountName, string notifyUrl, string callbackUrl, string MerchantUrl)
            : this(partner, key, sellerAccountName, notifyUrl, callbackUrl)
        {
            this.MerchantUrl = MerchantUrl;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionInfo"/> class.
        /// </summary>
        /// <param name="partner">The partner.</param>
        /// <param name="key">The key.</param>
        /// <param name="sellerAccountName">Name of the seller account.</param>
        /// <param name="notifyUrl">The notify URL.</param>
        /// <param name="callbackUrl">The callback URL.</param>
        /// <param name="MerchantUrl">The merchant URL.</param>
        /// <param name="transactionType">Type of the transaction.</param>
        /// <param name="serviceName">Name of the service.</param>
        public TransactionInfo(string partner, string key, string sellerAccountName, string notifyUrl, string callbackUrl, string MerchantUrl,TransactionType transactionType, string serviceName)
            : this(partner, key, sellerAccountName, notifyUrl, callbackUrl, MerchantUrl)
        {
            this.Type = transactionType;
            this.ServiceName = serviceName;
        }
    }
}
