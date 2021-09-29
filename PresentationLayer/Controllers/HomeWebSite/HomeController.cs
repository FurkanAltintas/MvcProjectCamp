using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers.HomeWebSite
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();
        // GET: Home
        public PartialViewResult Index()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Index(Contact p)
        {
            ValidationResult validationResult = contactValidator.Validate(p);

            if (validationResult.IsValid)
            {
                p.CreDate = DateTime.Now;
                contactManager.Add(p);
                return RedirectToAction("Index");
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

        public PartialViewResult Home()
        {
            return PartialView();
        }

        public PartialViewResult About()
        {
            return PartialView();
        }

        public PartialViewResult Service()
        {
            return PartialView();
        }

        public PartialViewResult Experience()
        {
            return PartialView();
        }

        public PartialViewResult Project()
        {
            return PartialView();
        }

        public PartialViewResult Statistic()
        {
            return PartialView();
        }

        public PartialViewResult Comment()
        {
            return PartialView();
        }

        public PartialViewResult Footer()
        {
            return PartialView();
        }

        public PartialViewResult Login()
        {
            return PartialView();
        }

        public PartialViewResult Register()
        {
            return PartialView();
        }
    }
}