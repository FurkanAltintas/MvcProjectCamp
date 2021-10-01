using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers.AdminDashboard
{
    public class CalendarController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Heading()
        {
            var list = headingManager.GetList();
            return PartialView(list);
        }

        public JsonResult Events()
        {
            return Json(headingManager.GetCalendar(), JsonRequestBehavior.AllowGet);
        }
    }
}