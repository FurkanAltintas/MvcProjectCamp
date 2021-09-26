using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Security
{
    public class BaseController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
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
                Mail = Session["Email"].ToString();

                var user = adminManager.GetByEmail(Mail);

                if (user == null)
                {
                    var writer = writerManager.GetByEmail(Mail);
                    FullName = writer.FullName;
                    Id = writer.Id;
                }
                else
                {
                    FullName = user.UserName;
                    Id = user.Id;
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}