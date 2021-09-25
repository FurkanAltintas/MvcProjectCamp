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
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        // GET: About
        public ActionResult Index()
        {
            var list = aboutManager.GetList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(About p)
        {
            aboutManager.Add(p);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var key = aboutManager.GetById(id);
            key.IsActive = !key.IsActive;
            aboutManager.Delete(key);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var key = aboutManager.GetById(id);
            return View(key);
        }

        [HttpPost]
        public ActionResult Edit(About p)
        {
            aboutManager.Update(p);
            return RedirectToAction("Index");
        }
    }
}