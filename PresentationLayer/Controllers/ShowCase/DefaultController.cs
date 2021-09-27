using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers.ShowCase
{
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        // GET: Default
        public PartialViewResult Index(int id)
        {
            if (id > 0)
            {
                var list = contentManager.GetByList(id);
                return PartialView(list);
            }
            else
            {
                var list = contentManager.GetList();
                return PartialView(list);
            }

        }

        public ActionResult Headings()
        {
            var list = headingManager.GetList();
            return View(list);
        }
    }
}