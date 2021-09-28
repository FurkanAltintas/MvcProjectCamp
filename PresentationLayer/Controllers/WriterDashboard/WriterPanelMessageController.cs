using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PresentationLayer.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers.WriterDashboard
{
    public class WriterPanelMessageController : WriterLoginController
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        // GET: WriterPanelMessage
        public ActionResult Index()
        {
            return View();
        }

        [Route("{WriterPanelMessage}/{Mail}/{mails}")] //filter ile inbox,sent mail, draft,starred ve trash bilgilerine erişebiliyoruz. Böyle 5 defa aynı kodu yazmamış olduk
        public ActionResult Mails(string mails, string filter)
        {
            if (filter == null && mails == null)
            {
                filter = "All";
                ViewBag.Title = "Inbox";
                var all = messageManager.GetListInbox(DontHashMail);
                return View(all);
            }

            switch (mails)
            {
                case "Inbox":
                    ViewBag.Title = "Inbox";
                    if (filter == "All")
                    {
                        var all = messageManager.GetListInbox(DontHashMail);
                        return View(all);
                    }
                    else if (filter == "Read")
                    {
                        var read = messageManager.GetListInboxRead(DontHashMail);
                        return View(read);
                    }
                    else if (filter == "Unread")
                    {
                        var unread = messageManager.GetListInboxUnRead(DontHashMail);
                        return View(unread);

                    }
                    return RedirectToAction("Index", "Contact");

                case "Sendbox":
                    ViewBag.Title = "Sendbox";
                    if (filter == "All")
                    {
                        var all = messageManager.GetListSendbox(DontHashMail);
                        return View(all);
                    }
                    else if (filter == "Read")
                    {
                        var read = messageManager.GetListSendboxRead(DontHashMail);
                        return View(read);
                    }
                    else if (filter == "Unread")
                    {
                        var unread = messageManager.GetListSendboxUnRead(DontHashMail);
                        return View(unread);

                    }
                    return RedirectToAction("Index", "Contact");

                case "Draft":
                    ViewBag.Title = "Draft";
                    if (filter == "All")
                    {
                        var all = messageManager.GetListDraft(DontHashMail);
                        return View(all);
                    }
                    else if (filter == "Read")
                    {
                        var read = messageManager.GetListDraftRead(DontHashMail);
                        return View(read);
                    }
                    else if (filter == "Unread")
                    {
                        var unread = messageManager.GetListDraftUnRead(DontHashMail);
                        return View(unread);

                    }
                    return RedirectToAction("Index", "Contact");

                case "Trash":
                    ViewBag.Title = "Trash";
                    if (filter == "All")
                    {
                        var all = messageManager.GetListTrash(DontHashMail);
                        return View(all);
                    }
                    else if (filter == "Read")
                    {
                        var read = messageManager.GetListTrashRead(DontHashMail);
                        return View(read);
                    }
                    else if (filter == "Unread")
                    {
                        var unread = messageManager.GetListTrashUnRead(DontHashMail);
                        return View(unread);
                    }
                    return RedirectToAction("Index", "Contact");

                case "Starred":
                    ViewBag.Title = "Starred";
                    if (filter == "All")
                    {
                        var all = messageManager.GetListStar(DontHashMail);
                        return View(all);
                    }
                    else if (filter == "Read")
                    {
                        var read = messageManager.GetListStarRead(DontHashMail);
                        return View(read);
                    }
                    else if (filter == "Unread")
                    {
                        var unread = messageManager.GetListStarUnRead(DontHashMail);
                        return View(unread);
                    }
                    return RedirectToAction("Index", "Contact");

                default:
                    return RedirectToAction("Index", "Contact");
            }
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult NewMessage(Message p, string menu)
        {
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

                p.SenderMail = Mail;
                p.IsActive = true;
                p.CreDate = DateTime.Now;
                messageManager.Add(p);
                return RedirectToAction("NewMessage");
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

        //[Route("{Message}/{Mail}/{mails}/{url}/{id}")]
        public ActionResult Detail(string url, int id)
        {
            var key = messageManager.GetById(id);

            if (key.IsDraft == true)
            {
                Session["DetailId"] = id;
                return View("Compose", key);
            }
            else if (key.IsRead == false)
            {
                key.IsRead = true;
                messageManager.Update(key);
            }

            return View(key);
        }

        public PartialViewResult Compose()
        {
            return PartialView();
        }

        public ActionResult IsStar(int id) //Yıldızlama işlemi id değerine göre halledilmektedir.
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
            return RedirectToAction("Mails");
        }
    }
}