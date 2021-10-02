using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using PresentationLayer.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers.AdminDashboard
{
    public class DashboardController : AdminLoginController
    {
        StatisticManager statisticManager = new StatisticManager(new CategoryManager(new EfCategoryDal()),
                                                                 new ContentManager(new EfContentDal()),
                                                                 new HeadingManager(new EfHeadingDal()),
                                                                 new WriterManager(new EfWriterDal()));

        MessageManager messageManager = new MessageManager(new EfMessageDal());

        AdminLoginController adminLoginController = new AdminLoginController(); //id alma
        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.Category = statisticManager.ListCategory();
            ViewBag.Content = statisticManager.ListContent();
            ViewBag.Heading = statisticManager.ListHeading();
            ViewBag.Writer = statisticManager.ListWriter();

            return View();
        }

        public PartialViewResult RecentMessage()
        {
            var inbox = messageManager.GetListInboxUnRead(DontHashMail);
            return PartialView(inbox);
        }

        public ActionResult Delete(int id)
        {
            var key = messageManager.GetById(id);
            key.IsTrash = true;
            key.CreDate = DateTime.Now;
            messageManager.Update(key);
            return RedirectToAction("Index");
        }

        public ActionResult Save(int id)
        {
            var key = messageManager.GetById(id);
            key.IsRead = true;
            key.CreDate = DateTime.Now;
            messageManager.Update(key);
            return RedirectToAction("Index");
        }
    }
}