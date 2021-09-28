using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace PresentationLayer.Controllers.AdminDashboard
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        ContactValidator contactValidator = new ContactValidator();
        // GET: Contact
        [Route("{controller}/{Mail}/{u}/{0}/{filter}")]
        public ActionResult Index(string filter)
        {
            if (filter == null)
            {
                filter = "All";
            }

            switch (filter)
            {
                case "All":
                    var list = contactManager.OrderByList();
                    return View(list);

                case "Read":
                    var read = contactManager.OrderByListRead();
                    return View(read);

                case "Unread":
                    var unread = contactManager.OrderByListUnread();
                    return View(unread);

                default:
                    var def = contactManager.OrderByList();
                    return View(def);
            }
        }

        public ActionResult Detail(int id)
        {
            var key = contactManager.GetById(id);
            return View(key);
        }

        //Partial Homework
        public ActionResult Compose() //partial
        {
            string mail = Session["DontHashMail"].ToString();

            ViewBag.Contact = contactManager.GetList().Count();
            ViewBag.Inbox = messageManager.GetListInbox(mail).Count();
            ViewBag.Sendbox = messageManager.GetListSendbox(mail).Count();
            ViewBag.Draft = messageManager.GetListDraft(mail).Count();
            ViewBag.Trash = messageManager.GetListTrash(mail).Count();
            ViewBag.Starred = messageManager.GetListStar(mail).Count();
            ViewBag.InboxAll = messageManager.GetListInbox(mail).Count();
            ViewBag.InboxRead = messageManager.GetListInboxRead(mail).Count();
            ViewBag.InboxUnread = messageManager.GetListInboxUnRead(mail).Count();

            //Service ve Manager kısmına eklemeden
            //ViewBag.Trash = messageManager.GetListTrash().Where(x=>x.IsTrash==true).Count(); 'şeklinde de yapılabilir'
            return View();
        }
    }
}