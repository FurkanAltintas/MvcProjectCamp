using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers.AdminDashboard
{
    public class DashboardController : Controller
    {
        StatisticManager statisticManager = new StatisticManager(new CategoryManager(new EfCategoryDal()),
                                                                 new ContentManager(new EfContentDal()),
                                                                 new HeadingManager(new EfHeadingDal()),
                                                                 new WriterManager(new EfWriterDal()));
        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.Category = statisticManager.ListCategory();
            ViewBag.Content = statisticManager.ListContent();
            ViewBag.Heading = statisticManager.ListHeading();
            ViewBag.Writer = statisticManager.ListWriter();

            return View();
        }
    }
}