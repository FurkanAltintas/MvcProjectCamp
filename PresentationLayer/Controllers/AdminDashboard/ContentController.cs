using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;

namespace PresentationLayer.Controllers.AdminDashboard
{
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        // GET: Content
        public ActionResult Index(int? page, string search)
        {
            var number = page ?? 1;

            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.Search = search;
                search = search.ToLower();
                var list = contentManager.GetSearch(search).ToPagedList(number, 10);
                return View(list);
            }
            else
            {
                var list = contentManager.GetList().ToPagedList(number, 10);
                return View(list);
            }
        }

        public ActionResult Detail(int id)
        {
            var key = contentManager.GetHeading(id);
            return View(key);
        }
    }
}