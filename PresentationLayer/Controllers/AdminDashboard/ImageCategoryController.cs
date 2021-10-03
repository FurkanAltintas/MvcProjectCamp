using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace PresentationLayer.Controllers.AdminDashboard
{
    public class ImageCategoryController : Controller
    {
        ImageCategoryManager imageCategoryManager = new ImageCategoryManager(new EfImageCategoryDal());
        // GET: GalleryCategory
        public ActionResult Index()
        {
            var list = imageCategoryManager.GetList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ImageCategory p)
        {
            p.IsActive = true;
            imageCategoryManager.Add(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var key = imageCategoryManager.GetById(id);
            return View(key);
        }

        [HttpPost]
        public ActionResult Edit(ImageCategory p)
        {
            p.IsActive = true;
            imageCategoryManager.Update(p);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var key = imageCategoryManager.GetById(id);

            key.IsActive = !key.IsActive;
            imageCategoryManager.Update(key);
            return RedirectToAction("Index");
        }

        public PartialViewResult Category()
        {
            var list = imageCategoryManager.GetList();
            return PartialView(list);
        }
    }
}