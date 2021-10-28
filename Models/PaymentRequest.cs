using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Models.PaymentObjects;

namespace WebApplication4.Models
{
    public class PaymentRequest
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public riskdata riskData { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public paymentMethod paymentMethod { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string storePaymentMethod { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public browserInfo browserInfo { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string clientStateDataIndicator { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string merchantAccount { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string reference { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Amount amount { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public additionalData additionalData { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string returnUrl { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string channel { get; set; }
        public PaymentRequest() {
            this.additionalData = new additionalData();
        }
    }
}