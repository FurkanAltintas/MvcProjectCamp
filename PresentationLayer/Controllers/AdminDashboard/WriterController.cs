using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using FluentValidation.Results;

namespace PresentationLayer.Controllers.AdminDashboard
{
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        private ContentManager contentManager = new ContentManager(new EfContentDal());
        WriterValidator writerValidator = new WriterValidator();
        WriterDetail writerDetail = new WriterDetail();

        // GET: Writer
        public ActionResult Index()
        {
            var list = writerManager.GetList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Writer p)
        {
            ValidationResult validationResult = writerValidator.Validate(p);
            if (validationResult.IsValid)
            {
                writerManager.Add(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            writerDetail.Writer = writerManager.GetById(id);
            writerDetail.Content = contentManager.GetWriter(id);
            return View(writerDetail);
        }

        [HttpPost]
        public ActionResult Detail(WriterDetail p, int id)
        {
            p.Writer.Id = id;

            ValidationResult validationResult = writerValidator.Validate(p.Writer);

            if (validationResult.IsValid)
            {
                writerManager.Update(p.Writer);
                return RedirectToAction("Detail", "Writer", new { id = p.Writer.Id });
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View("Detail", p);
        }
    }
}