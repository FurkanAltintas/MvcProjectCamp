using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers.HomeWebSite
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Service()
        {
            return View();
        }

        public ActionResult Experience()
        {
            return View();
        }

        public ActionResult Project()
        {
            return View();
        }

        public ActionResult Statistic()
        {
            return View();
        }

        public ActionResult Comment()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Footer()
        { 
            return View(); 
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}