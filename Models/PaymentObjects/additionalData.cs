using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.PaymentObjects
{
    public class additionalData
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Boolean allow3DS2  { get; set; }
    }
}