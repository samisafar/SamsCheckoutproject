using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public partial class Amount 
    {

        public string currency { get; set; }
        public long? value { get; set; }
        public Amount(string currency = default(string), long? value = default(long?))
        {
            // to ensure "currency" is required (not null)
            if (currency == null)
            {
                throw new InvalidDataException("currency is a required property for Amount and cannot be null");
            }
            else
            {
                this.currency = currency;
            }
            // to ensure "value" is required (not null)
            if (value == null)
            {
                throw new InvalidDataException("value is a required property for Amount and cannot be null");
            }
            else
            {
                this.value = value;
            }
        }
        
    }
}
