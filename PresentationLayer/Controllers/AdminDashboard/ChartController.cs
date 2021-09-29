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
    public class ChartController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        // GET: Chart
        public ActionResult Category()
        {
            return View();
        }

        public ActionResult Heading()
        {
            return View();
        }

        public ActionResult Content()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(categoryManager.GetChart(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult HeadingChart()
        {
            return Json(headingManager.GetChart(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ContentChart()
        {
            return Json(contentManager.GetChart(), JsonRequestBehavior.AllowGet);
        }
    }
}