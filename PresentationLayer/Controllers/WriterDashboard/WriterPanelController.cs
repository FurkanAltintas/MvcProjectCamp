using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using PresentationLayer.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers.WriterDashboard
{
    public class WriterPanelController : WriterLoginController
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();
        // GET: Writer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyHeading()
        {
            var list = headingManager.GetByWriterList(Id);
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            Category();
            return View();
        }

        [HttpPost]
        public ActionResult Add(Heading p)
        {
            p.WriterId = Id;
            p.IsActive = true;
            p.CreDate = DateTime.Now;
            headingManager.Add(p);
            return RedirectToAction("MyHeading");
        }

        public ActionResult Delete(int id)
        {
            var key = headingManager.GetById(id);
            //key.IsActive = key.IsActive != true;
            //daha az kodlu hali
            key.IsActive = !key.IsActive;
            headingManager.Delete(key);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Category();
            var key = headingManager.GetById(id);
            key.IsActive = true;
            return View(key);
        }

        [HttpPost]
        public ActionResult Edit(Heading p)
        {
            headingManager.Update(p);
            return RedirectToAction("MyHeading");
        }

        public ActionResult All(int? page)
        {
            var number = page ?? 1;

            var list = headingManager.GetList().ToPagedList(number, 5);
            return View(list);
        }

        public ActionResult Profile()
        {
            ViewBag.Mail = DontHashMail;

            var mail = writerManager.GetByEmail(Mail);
            return View(mail);
        }

        [HttpPost]
        public ActionResult Profile(Writer p)
        {
            ValidationResult validationResult = writerValidator.Validate(p);

            if (validationResult.IsValid)
            {
                writerManager.Update(p);
                return RedirectToAction("Profile");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(p);
        }

        public PartialViewResult WriterContent()
        {
            var list = contentManager.GetWriter(Id);
            return PartialView(list);
        }

        public void Category()
        {
            ViewBag.Category = new SelectList(categoryManager.GetList().OrderBy(x => x.Name), "Id", "Name");
        }
    }
}