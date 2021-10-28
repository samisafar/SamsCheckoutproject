using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class ResultController : Controller
    {
        // GET: Result
        public ActionResult success()
        {
            return View();
        }
        public ActionResult error()
        {
            return View();
        }
    }
}