using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using PresentationLayer.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers.WriterDashboard
{
    public class WriterPanelContentController : WriterLoginController
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        // GET: WriterPanelContent
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyContent()
        {
            var key = contentManager.GetWriter(Id);
            return View(key);
        }
    }
}