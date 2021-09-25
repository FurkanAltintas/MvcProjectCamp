using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            if (adminManager.GetLogin(p))
            {
                //var user = adminManager.GetByEmail(p.Email);

                FormsAuthentication.SetAuthCookie(p.Email, false);
                Session["Email"] = p.Email;
                //Session["UserName"] = user.UserName;
                //Session["Profile"] = user.Profile;
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ViewBag.Error = "Username or password is wrong";
                return View(p);
            }
        }

        public ActionResult LockScreen()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}