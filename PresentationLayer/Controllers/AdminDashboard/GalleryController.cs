using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace PresentationLayer.Controllers.AdminDashboard
{
    public class GalleryController : Controller
    {
        ImageManager imageManager = new ImageManager(new EfImageDal());
        // GET: Gallery
        public ActionResult Index()
        {
            var list = imageManager.GetListOrderBy();
            return View(list);
        }
    }
}