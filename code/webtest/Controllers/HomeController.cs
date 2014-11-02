using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webtest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This application serves as the results of the OGSys web test.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Information for Steve Zilligen.";

            return View();
        }
    }
}
