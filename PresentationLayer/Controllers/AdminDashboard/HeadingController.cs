using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace PresentationLayer.Controllers.AdminDashboard
{
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        // GET: Heading
        public ActionResult Index()
        {
            var list = headingManager.GetList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            #region ListCategory
            //Controller
            //List<SelectListItem> category = (from x in categoryManager.GetList()
            //                                 select new SelectListItem
            //                                 {
            //                                     Text = x.Name,
            //                                     Value = x.Id.ToString()
            //                                 }).ToList();
            //ViewBag.Category = category;

            //View
            //@Html.DropDownListFor(x => x.CategoryId, (List<SelectListItem>)ViewBag.Category, "Select Category", new {@class="form-control"})

            //-------------------------------------------------------------------------------------------------------

            //Controller
            //List<SelectListItem> writer = (from x in writerManager.GetList()
            //                                 select new SelectListItem
            //                                 {
            //                                     Text = x.Name + " " + x.SurName,
            //                                     Value = x.Id.ToString()
            //                                 }).ToList();
            //ViewBag.Writer = writer;

            //View
            //@Html.DropDownListFor(x => x.WriterId, (List<SelectListItem>)ViewBag.Writer, "Select Writer", new {@class="form-control"})
            #endregion

            ViewBag.Writer = new SelectList(writerManager.GetList().OrderBy(x => x.FullName), "Id", "FullName");

            Category();
            return View();
        }

        [HttpPost]
        public ActionResult Add(Heading p)
        {
            p.CreDate = DateTime.Now;
            headingManager.Add(p);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var key = headingManager.GetById(id);
            //key.IsActive = key.IsActive != true;
            //daha az kodlu hali
            key.IsActive = !key.IsActive;
            headingManager.Delete(key);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        public void Category()
        {
            ViewBag.Category = new SelectList(categoryManager.GetList().OrderBy(x => x.Name), "Id", "Name");
        }
    }
}