using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace PresentationLayer.Controllers.AdminDashboard
{
    public class GalleryController : Controller
    {
        ImageManager imageManager = new ImageManager(new EfImageDal());
        ImageCategoryManager imageCategoryManager = new ImageCategoryManager(new EfImageCategoryDal());
        ImageValidator imageValidator = new ImageValidator();
        // GET: Gallery
        public ActionResult Index()
        {
            ViewBag.Success = TempData["Success"] as string;
            ViewBag.Error = TempData["Error"] as string;
            ViewBag.Extension = TempData["Extension"] as string;
            ViewBag.Delete = TempData["Delete"] as string;
            ViewBag.Update = TempData["Update"] as string;

            var list = imageManager.GetListOrderBy();
            return View(list);
        }

        [HttpGet]
        public PartialViewResult FileUpload()
        {
            Image();
            return PartialView();
        }

        [HttpPost]
        public ActionResult FileUpload(Image p)
        {
            ValidationResult validationResult = imageValidator.Validate(p);

            if (validationResult.IsValid)
            {
                //var file = Request.Files[0];
                //string uzanti = Path.GetExtension(file.FileName);

                string folderPath = Server.MapPath("~/Images/Assets/");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string expansion = Path.GetExtension(Request.Files[0].FileName);

                if (expansion == ".jpg" || expansion == ".jpeg" || expansion == ".png" || expansion == ".gif")
                {
                    //string dosyaAdi = Path.GetFileName(file.FileName);
                    //string adres = "/Images/Assets/" + dosyaAdi;
                    //Request.Files[0].SaveAs(Server.MapPath(adres));
                    //p.Url = adres;

                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    string path = "http://furkanaltintas-001-site1.htempurl.com/Images/Assets/" + fileName;
                    var fullpath = Server.MapPath("/Images/Assets/") + fileName;
                    Request.Files[0].SaveAs(Server.MapPath(path));
                    p.Url = path;
                    p.IsActive = true;
                    p.CreDate = DateTime.Now;
                    TempData["Success"] = "Success";
                    imageManager.Add(p);
                }
                else
                {
                    TempData["Extension"] = "Error";
                    Image();
                }
            }
            else
            {
                TempData["Error"] = "Error";
                Image();

                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var key = imageManager.GetById(id);
            imageManager.Delete(key);
            TempData["Delete"] = "Delete";
            return RedirectToAction("Index");
        }

        public void Image()
        {
            ViewBag.Image = new SelectList(imageCategoryManager.GetList(), "Id", "Name");
        }
    }
}