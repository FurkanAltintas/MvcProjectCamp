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
        // GET: Chart
        public ActionResult Index()
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
            return Json(categoryManager.GetChart(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ContentChart()
        {
            return Json(categoryManager.GetChart(), JsonRequestBehavior.AllowGet);
        }
    }
}