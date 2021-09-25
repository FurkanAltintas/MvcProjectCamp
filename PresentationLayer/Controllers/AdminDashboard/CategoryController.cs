using System;
using System.Collections.Generic;
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
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        CategoryValidator categoryValidator = new CategoryValidator();

        [Authorize(Roles ="Yönetici")]
        // GET: Category
        public ActionResult Index()
        {
            var list = categoryManager.GetList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category p)
        {
            ValidationResult validationResult = categoryValidator.Validate(p);

            if (validationResult.IsValid)
            {
                categoryManager.Add(p);
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

        public ActionResult Delete(int id)
        {
            var key = categoryManager.GetById(id);
            categoryManager.Delete(key);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var key = categoryManager.GetById(id);
            return View(key);
        }

        [HttpPost]
        public ActionResult Edit(Category p)
        {
            ValidationResult validationResult = categoryValidator.Validate(p);

            if (validationResult.IsValid)
            {
                categoryManager.Update(p);
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
    }
}