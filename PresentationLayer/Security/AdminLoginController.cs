using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Security
{
    public class AdminLoginController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());

        public int Id { get; set; }
        public string Mail { get; set; }
        public string DontHashMail { get; set; }
        public string FullName { get; set; }
        public string Profile { get; set; }
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
                DontHashMail = (string)Session["DontHashMail"];
                var user = adminManager.GetByEmail(Mail);
                FullName = user.UserName;
                Profile = user.Profile;
                Id = user.Id;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}