using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.PaymentObjects
{
    public class riskdata
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string clientData { get; set; }
    }
}