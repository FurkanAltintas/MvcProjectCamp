﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers.WriterDashboard
{
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        // GET: Writer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyHeading()
        {
            int id = 4;
            var list = headingManager.GetByList(id);
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
            p.WriterId = 4;
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
            return View(key);
        }

        [HttpPost]
        public ActionResult Edit(Heading p)
        {
            headingManager.Update(p);
            return RedirectToAction("MyHeading");
        }

        public void Category()
        {
            ViewBag.Category = new SelectList(categoryManager.GetList().OrderBy(x => x.Name), "Id", "Name");
        }
    }
}