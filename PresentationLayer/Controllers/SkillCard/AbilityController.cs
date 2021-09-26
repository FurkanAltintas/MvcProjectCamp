using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PresentationLayer.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers.SkillCard
{
    public class AbilityController : AdminLoginController
    {
        AbilityManager abilityManager = new AbilityManager(new EfAbilityDal());
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        // GET: Ability
        public ActionResult Index()
        {
            ViewBag.User = FullName;
            var list = abilityManager.GetOrderList(Mail);
            return View(list);
        }

        [Route("{Dashboard/{controller}/{Appearance}/{name}")]
        public ActionResult Appearance(string name)
        {
            var list = abilityManager.GetOrderList(Mail);
            return View(list);
        }

        public ActionResult Person()
        {
            var user = adminManager.GetByEmail(Mail);
            return View(user);
        }

        public ActionResult Detail(int id)
        {
            var key = abilityManager.GetById(id);
            return View(key);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Ability p)
        {
            p.AdminId = Id;
            abilityManager.Add(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var key = abilityManager.GetById(id);
            return View(key);
        }

        [HttpPost]
        public ActionResult Edit(Ability p)
        {
            p.AdminId = Id;
            abilityManager.Update(p);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var key = abilityManager.GetById(id);
            abilityManager.Delete(key);
            return RedirectToAction("Index");
        }
    }
}