using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Security
{
    public class WriterLoginController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        public int Id { get; set; }
        public string Mail { get; set; }
        public string FullName { get; set; }
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["Email"] == null)
            {
                //boş ise geri dönüş
            }
            else
            {
                Mail = (string)Session["Email"];
                var user = writerManager.GetByEmail(Mail);
                FullName = user.FullName;
                Id = user.Id;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}