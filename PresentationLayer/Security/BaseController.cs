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
                FullName = user.UserName;
                Id = user.Id;

            }
            base.OnActionExecuting(filterContext);
        }
    }
}