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
    [Route("{controller}/{action}")]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();
        // GET: Home
        public PartialViewResult Index()
        {
            ViewBag.ContactTrue = TempData["True"] as string;
            ViewBag.ContactFalse = TempData["False"] as string;
            return PartialView();
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


        [HttpGet]
        public PartialViewResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Contact p)
        {
            ValidationResult validationResult = contactValidator.Validate(p);

            if (validationResult.IsValid)
            {
                p.CreDate = DateTime.Now;
                contactManager.Add(p);
                TempData["True"] = "Successful";
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    TempData["False"] = "Failed";
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction("Index");
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