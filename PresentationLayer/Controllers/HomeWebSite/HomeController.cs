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
        public PartialViewResult Index()
        {
            return PartialView();
        }

        public PartialViewResult Home()
        {
            return PartialView();
        }

        public PartialViewResult About()
        {
            return PartialView();
        }

        public PartialViewResult Service()
        {
            return PartialView();
        }

        public PartialViewResult Experience()
        {
            return PartialView();
        }

        public PartialViewResult Project()
        {
            return PartialView();
        }

        public PartialViewResult Statistic()
        {
            return PartialView();
        }

        public PartialViewResult Comment()
        {
            return PartialView();
        }

        public PartialViewResult Contact()
        {
            return PartialView();
        }

        public PartialViewResult Footer()
        { 
            return PartialView(); 
        }

        public PartialViewResult Login()
        {
            return PartialView();
        }

        public PartialViewResult Register()
        {
            return PartialView();
        }
    }
}