using Gbi.Service.Common;
using Gbi.Service.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gbi.Payment.Core
{
    /// <summary>
    /// Class Framework.
    /// </summary>
    public class Framework : BaseFramework<Framework>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Framework"/> class.
        /// </summary>
        public Framework()
            : base("Gbi.PaymentService")
        { }

        /// <summary>
        /// The key
        /// </summary>
        const string key = "Key";

        /// <summary>
        /// The seller account name
        /// </summary>
        const string sellerAccountName = "SellerAccountName";

        /// <summary>
        /// The partner
        /// </summary>
        const string partner = "Partner";

        /// <summary>
        /// The notify URL
        /// </summary>
        const string notifyUrl = "NotifyUrl";

        /// <summary>
        /// The call back URL
        /// </summary>
        const string callBackUrl = "CallBackUrl";

        /// <summary>
        /// The merchant URL
        /// </summary>
        const string merchantUrl = "MerchantUrl";

        /// <summary>
        /// The key
        /// </summary>
        public static readonly string Key = ConfigurationUtil.Instance.GetValueByKey<string>(key);

        /// <summary>
        /// The seller account name
        /// </summary>
        public static readonly string SellerAccountName = ConfigurationUtil.Instance.GetValueByKey<string>(sellerAccountName);

        /// <summary>
        /// The partner
        /// </summary>
        public static readonly string Partner = ConfigurationUtil.Instance.GetValueByKey<string>(partner);

        /// <summary>
        /// The notify URL
        /// </summary>
        public static readonly string NotifyUrl = ConfigurationUtil.Instance.GetValueByKey<string>(notifyUrl);

        /// <summary>
        /// The call back URL
        /// </summary>
        public static readonly string CallBackUrl = ConfigurationUtil.Instance.GetValueByKey<string>(callBackUrl);

        /// <summary>
        /// The merchant URL
        /// </summary>
        public static readonly string MerchantUrl = ConfigurationUtil.Instance.GetValueByKey<string>(merchantUrl);
    
    }
}
