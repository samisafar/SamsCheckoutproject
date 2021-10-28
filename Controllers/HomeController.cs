using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{

    public class HomeController : Controller
    {
        public string MerchantAccount = ConfigurationManager.AppSettings["MerchantAccount"];
        public string Channel = ConfigurationManager.AppSettings["Channel"];
        public async Task<ActionResult> Index()
        {
            Amount amount = new Amount("USD", 61000);
            
            PaymentModel checkout = new PaymentModel();
            String paymentMethodsResponse = await checkout.GetPaymentMethods(MerchantAccount, amount, Channel, "CN", "en_US");
            ViewBag.paymentMethodsResponse = paymentMethodsResponse;
            return View();
        }


        [System.Web.Mvc.HttpPost]
        public async Task<string> Pay([FromBody] PaymentRequest data)
        {
            Amount amount = new Amount("USD", 61000);
            data.merchantAccount = MerchantAccount;
            data.amount = amount;
            data.reference = "Sami_checkoutChallenge";
            data.channel = Channel;
            data.additionalData.allow3DS2 = true;
            data.returnUrl = "http://localhost:8080/Home/HandleRedirect";
            PaymentModel Payment = new PaymentModel();
            string paymentResponse = await Payment.ExecutePayment(data);

            return paymentResponse;
        }


        public async Task<ActionResult> HandleRedirect()
        {
            DetailsRequest request = new DetailsRequest();
            string Query = HttpContext.Request.QueryString.GetValues("redirectResult")[0];
            PaymentModel Payment = new PaymentModel();
            request.details.redirectResult = WebUtility.UrlDecode(Query);
            DetailsResponse paymentDetails = await Payment.GetPaymentDetails(request);
            switch (paymentDetails.resultCode)
            {
                case "Authorised":
                    return View("success");
                case "Refused":
                    return View("failed");
                case "Pending":
                    return View("pending");
                default:
                    return View("error");
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}