using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace PresentationLayer.Controllers.AdminDashboard
{
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        // GET: Message

        //RouteConfig işlemi ile kod fazlalığından kurtulduk. Switch case ile işlem halledildi

        #region Inbox
        //public ActionResult Inbox()
        //{
        //    var list = messageManager.GetListInbox();
        //    return View(list);
        //}
        #endregion

        #region Sendbox
        //public ActionResult Sendbox()
        //{
        //    var list = messageManager.GetListSendbox();
        //    return View(list);
        //}
        #endregion

        #region Draft
        //public ActionResult Draft()
        //{
        //    var list = messageManager.GetListDraft();
        //    return View(list);
        //}
        #endregion

        #region Trash
        //public ActionResult Trash()
        //{
        //    var list = messageManager.GetListTrash();
        //    return View(list);
        //}
        #endregion

        #region Starred
        //public ActionResult Starred()
        //{
        //    var list = messageManager.GetListStar();
        //    return View(list);
        //}
        #endregion

        //[Route("{Message}/{Mail}/{mails}/{url}/{id}")]
        public ActionResult Detail(string url, int id)
        {
            var key = messageManager.GetById(id);

            if (key.IsDraft == true)
            {
                Session["DetailId"] = id;
                return View("Compose", key);
            }
            else if (key.IsRead == true)
            {

            }
            else
            {
                key.IsRead = true;
                messageManager.Update(key);
            }
            return View(key);
        }

        [HttpGet]
        public ActionResult Compose()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Compose(Message p, string menu)
        {
            string mail = Session["Email"].ToString();

            ValidationResult validationResult = messageValidator.Validate(p);

            if (Session["DetailId"] != null)
            {
                int id = (int)Session["DetailId"];
                var key = messageManager.GetById(id);
                messageManager.Delete(key);
            }

            if (validationResult.IsValid)
            {
                switch (menu)
                {
                    case "send":
                        p.IsSend = true;
                        break;
                    case "trash":
                        p.IsTrash = true;
                        break;
                    case "draft":
                        p.IsDraft = true;
                        break;
                    case "reset":
                        return RedirectToAction("Compose");
                    case "":
                        return RedirectToAction("Compose");
                }

                p.SenderMail = mail;
                p.IsActive = true;
                p.CreDate = DateTime.Now;
                messageManager.Add(p);
                return RedirectToAction("Compose");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        } //menu işlemi mailin taslak mı silincek mi veya gönderilceği ile ilgili. Gelen değere göre switch case ile işlem yapılmaktadır.

        public ActionResult IsStar(int id)
        {
            var key = messageManager.GetById(id);

            if (key.IsStar == true)
            {
                key.IsStar = false;
            }
            else
            {
                key.IsStar = true;
            }
            messageManager.Update(key);
            return RedirectToAction("Inbox");
        } //Yıldızlama işlemi id değerine göre halledilmektedir.

        [Route("{Message}/{Mail}/{mails}")] //filter ile inbox,sent mail, draft,starred ve trash bilgilerine erişebiliyoruz. Böyle 5 defa aynı kodu yazmamış olduk
        public ActionResult Mails(string mails, string filter)
        {
            string mail = Session["Email"].ToString();

            if (filter == null)
            {
                filter = "All";
            }

            switch (mails)
            {
                case "Inbox":
                    ViewBag.Title = "Inbox";
                    if (filter == "All")
                    {
                        var all = messageManager.GetListInbox(mail);
                        return View(all);
                    }
                    else if (filter == "Read")
                    {
                        var read = messageManager.GetListInboxRead(mail);
                        return View(read);
                    }
                    else if (filter == "Unread")
                    {
                        var unread = messageManager.GetListInboxUnRead(mail);
                        return View(unread);

                    }
                    return RedirectToAction("Index", "Contact");

                case "Sendbox":
                    ViewBag.Title = "Sendbox";
                    if (filter == "All")
                    {
                        var all = messageManager.GetListSendbox(mail);
                        return View(all);
                    }
                    else if (filter == "Read")
                    {
                        var read = messageManager.GetListSendboxRead(mail);
                        return View(read);
                    }
                    else if (filter == "Unread")
                    {
                        var unread = messageManager.GetListSendboxUnRead(mail);
                        return View(unread);

                    }
                    return RedirectToAction("Index", "Contact");

                case "Draft":
                    ViewBag.Title = "Draft";
                    if (filter == "All")
                    {
                        var all = messageManager.GetListDraft(mail);
                        return View(all);
                    }
                    else if (filter == "Read")
                    {
                        var read = messageManager.GetListDraftRead(mail);
                        return View(read);
                    }
                    else if (filter == "Unread")
                    {
                        var unread = messageManager.GetListDraftUnRead(mail);
                        return View(unread);

                    }
                    return RedirectToAction("Index", "Contact");

                case "Trash":
                    ViewBag.Title = "Trash";
                    if (filter == "All")
                    {
                        var all = messageManager.GetListTrash(mail);
                        return View(all);
                    }
                    else if (filter == "Read")
                    {
                        var read = messageManager.GetListTrashRead(mail);
                        return View(read);
                    }
                    else if (filter == "Unread")
                    {
                        var unread = messageManager.GetListTrashUnRead(mail);
                        return View(unread);
                    }
                    return RedirectToAction("Index", "Contact");

                case "Starred":
                    ViewBag.Title = "Starred";
                    if (filter == "All")
                    {
                        var all = messageManager.GetListStar(mail);
                        return View(all);
                    }
                    else if (filter == "Read")
                    {
                        var read = messageManager.GetListStarRead(mail);
                        return View(read);
                    }
                    else if (filter == "Unread")
                    {
                        var unread = messageManager.GetListStarUnRead(mail);
                        return View(unread);
                    }
                    return RedirectToAction("Index", "Contact");

                default:
                    return RedirectToAction("Index", "Contact");
            }
        }
    }
}