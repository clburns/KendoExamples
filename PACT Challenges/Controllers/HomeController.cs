using PACT_Challenges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PACT_Challenges.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            var c = new Contact
            {
                ContactID = 0,
                FirstName = "f",
                LastName = "z",
                Email = "q",
                PhoneNumber = "c",
                Company = "p"
            };
            return null;
        }
    }
}
