using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace PresentationLayer.Controllers.AdminDashboard
{
    public class GalleryCategoryController : Controller
    {
        ImageCategoryManager imageCategoryManager = new ImageCategoryManager(new EfImageCategoryDal());
        // GET: GalleryCategory
        public ActionResult Index()
        {
            var list = imageCategoryManager.GetList();
            return View(list);
        }
    }
}