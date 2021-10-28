using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Mvc;
using System.Configuration;

namespace WebApplication4.Models
{
    public class PaymentModel
    {
        public string Baseurl = ConfigurationManager.AppSettings["Baseurl"];
        public string xAPIkey = ConfigurationManager.AppSettings["x-API-key"];
        [HttpPost]
        public async Task  <string> GetPaymentMethods(String merchantAccount, Amount amount, String channel, String countryCode, String shopperLocale)
        {
            PaymentMethodRequest request = new PaymentMethodRequest(merchantAccount, amount, channel, countryCode, shopperLocale);

            var json = JsonConvert.SerializeObject(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-API-key", xAPIkey);
                
                //Sending request to find web api REST service resource paymentMethods using HttpClient
                HttpResponseMessage Res = await client.PostAsync("v67/paymentMethods", data);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                     return JsonConvert.DeserializeObject(Res.Content.ReadAsStringAsync().Result).ToString();
                }
                return null ;
            }

        }


        [HttpPost]
        public async Task<String> ExecutePayment(PaymentRequest state)
        {
            var json = JsonConvert.SerializeObject(state);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-API-key", xAPIkey);

                //Sending request to find web api REST service resource paymentMethods using HttpClient
                HttpResponseMessage Res = await client.PostAsync("v67/payments", data);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject(Res.Content.ReadAsStringAsync().Result).ToString();
                }
                return null;
            }
        }
            [HttpPost]
            public async Task<DetailsResponse> GetPaymentDetails(DetailsRequest detailsRequest)
            {

                var json = JsonConvert.SerializeObject(detailsRequest);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    //Passing service base url
                    client.BaseAddress = new Uri(Baseurl);
                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("x-API-key", xAPIkey);

                    //Sending request to find web api REST service resource paymentMethods using HttpClient
                    HttpResponseMessage Res = await client.PostAsync("v67/payments/details", data);
                    //Checking the response is successful or not which is sent using HttpClient
                    if (Res.IsSuccessStatusCode)
                    {
                    var DetailsResponse = JsonConvert.DeserializeObject<DetailsResponse>(Res.Content.ReadAsStringAsync().Result);
                    return DetailsResponse;
                    }
                    return null;
                }
            }



    }
}