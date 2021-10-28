using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.PaymentObjects
{
    public class paymentMethod
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string type { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string holderName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string encryptedCardNumber { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string encryptedExpiryMonth { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string encryptedExpiryYear { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string encryptedSecurityCode { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string brand { get; set; }
    }
}