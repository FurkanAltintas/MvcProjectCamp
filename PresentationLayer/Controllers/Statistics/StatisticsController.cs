using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace PresentationLayer.Controllers.Statistics
{
    public class StatisticsController : Controller
    {
        private Context c = new Context();
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        // GET: Statistics
        public ActionResult Index()
        {
            //toplam kategori sayısı
            var category = categoryManager.GetList().Count();
            ViewBag.Category = category;

            //başlık tablosunda 'yazılım' kategorisine ait başlık sayısı
            var software = headingManager.CategoryCount();
            ViewBag.Software = software;

            //yazar adında 'a' harfi geçen yazar sayısı
            var writer = writerManager.WriterCountA();
            ViewBag.Writer = writer;

            //en fazla başlığa sahip kategori adı
            var heading = c.Category.Where(x => x.Id == c.Heading.GroupBy(h => h.Id)
                          .OrderByDescending(y => y.Count()).Select(k => k.Key)
                          .FirstOrDefault()).Select(x => x.Name).FirstOrDefault();
            ViewBag.Heading = heading;

            //kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
            var status = categoryManager.StatusTrue() - categoryManager.StatusFalse();
            ViewBag.CategoryStatus = status;

            return View();
        }
    }
}