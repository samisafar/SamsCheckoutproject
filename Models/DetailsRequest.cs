using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Models.PaymentObjects;

namespace WebApplication4.Models
{
    public class DetailsRequest
    {
        public details details { get; set; }

        public DetailsRequest()
        {
            this.details = new details();
        }
    }
}