using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogV1.Controllers
{
    [RequireHttps]
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        public ActionResult Photo()
        {
            return View();
        }

        // GET: Code
        public ActionResult Code()
        {
            return View();
        }

        public ActionResult design()
        {
            return View();
        }
    }
}