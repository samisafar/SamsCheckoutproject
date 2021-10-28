using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.PaymentObjects
{
    public class browserInfo
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string acceptHeader { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string colorDepth { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string language { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string javaEnabled { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string screenHeight { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string screenWidth { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string userAgent { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string timeZoneOffset { get; set; }
    }
}