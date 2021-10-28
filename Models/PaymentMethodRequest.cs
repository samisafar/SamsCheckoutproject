using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication4.Models
{
    public class PaymentMethodRequest
    {

        public String merchantAccount { get; set; }
        public Amount amount { get; set; }
        public String channel { get; set; }
        public String countryCode { get; set; }
        public String shopperLocale { get; set; }

        public PaymentMethodRequest(String merchantAccount, Amount amount, String channel,string countryCode, string shopperLocale) {

            this.merchantAccount = merchantAccount;
            this.amount = amount;
            this.channel = channel;
            this.countryCode = countryCode;
            this.shopperLocale = shopperLocale;
        }


      
    }
}