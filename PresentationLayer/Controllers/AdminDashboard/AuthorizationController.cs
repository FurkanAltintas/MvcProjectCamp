using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PresentationLayer.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers.AdminDashboard
{
    public class AuthorizationController : AdminLoginController
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        AdminValidator adminValidator = new AdminValidator();
        AdminRoleManager adminRoleManager = new AdminRoleManager(new EfAdminRoleDal());
        // GET: Authorization
        public ActionResult Index()
        {
            ViewBag.Added = TempData["Added"] as string;
            ViewBag.Updated = TempData["Updated"] as string;
            ViewBag.Delete = TempData["Delete"] as string;
            ViewBag.Role = TempData["Role"] as string;
            var list = adminManager.GetList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            Role();
            return View();
        }

        [HttpPost]
        public ActionResult Add(Admin p)
        {
            ValidationResult validationResult = adminValidator.Validate(p);

            if (validationResult.IsValid)
            {
                p.CreDate = DateTime.Now;
                adminManager.Add(p);
                TempData["Added"] = "Added";
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    Role();
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(p);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Role();
            var key = adminManager.GetById(id);
            return View(key);
        }

        [HttpPost]
        public ActionResult Edit(int id, Admin p)
        {
            ValidationResult validationResult = adminValidator.Validate(p);

            if (validationResult.IsValid)
            {
                p.IsActive = true;
                p.ModDate = DateTime.Now;
                adminManager.Update(p);
                TempData["Updated"] = "Updated";
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    Role();
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(p);
        }

        public ActionResult Delete(int id)
        {
            var key = adminManager.GetById(id);
            key.IsActive = !key.IsActive;
            adminManager.IsStatus(key);
            TempData["Delete"] = "Delete";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ChangeRole(int id)
        {
            Role();
            var key = adminManager.GetById(id);
            return View(key);
        }

        [HttpPost]
        public ActionResult ChangeRole(int id, Admin p)
        {
            adminManager.GetRoleById(id, p.AdminRoleId);
            TempData["Role"] = "Updated";
            return RedirectToAction("Index");
        }

        public void Role()
        {
            ViewBag.Role = new SelectList(adminRoleManager.GetList(), "Id", "Name");
        }
    }
}