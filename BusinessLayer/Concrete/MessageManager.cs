using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetList()
        {
            return _messageDal.List();
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.Id == id);
        }

        public void Add(Message p)
        {
            _messageDal.Insert(p);
        }

        public void Update(Message p)
        {
            _messageDal.Update(p);
        }

        public void Delete(Message p)
        {
            _messageDal.Delete(p);
        }

        public IOrderedEnumerable<Message> OrderByList(string p)
        {
            return _messageDal.List().OrderByDescending(x => x.Id);
        }

        public IOrderedEnumerable<Message> GetListInbox(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p && x.IsTrash == false && x.IsDraft == false).OrderByDescending(x => x.Id);
        }

        public IOrderedEnumerable<Message> GetListSendbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p && x.IsTrash == false).OrderByDescending(x => x.Id);
        }

        public IOrderedEnumerable<Message> GetListTrash(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p && x.IsTrash == true).OrderByDescending(x => x.Id);
        }

        public IOrderedEnumerable<Message> GetListDraft(string p)
        {
            return _messageDal.List(x => x.SenderMail == p && x.IsDraft == true).OrderByDescending(x => x.Id);
        }

        public IOrderedEnumerable<Message> GetListStar(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p && x.IsStar == true).OrderByDescending(x => x.Id);
        }

        public IOrderedEnumerable<Message> GetListInboxRead(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p && x.IsRead == true && x.IsTrash == false && x.IsDraft == false).OrderByDescending(x => x.Id);
        }

        public IOrderedEnumerable<Message> GetListInboxUnRead(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p && x.IsRead == false && x.IsTrash == false && x.IsDraft == false).OrderByDescending(x => x.Id);
        }

        public IOrderedEnumerable<Message> GetListSendboxRead(string p)
        {
            return _messageDal.List(x => x.SenderMail == p && x.IsRead == true && x.IsTrash == false).OrderByDescending(x => x.Id);
        }

        public IOrderedEnumerable<Message> GetListSendboxUnRead(string p)
        {
            return _messageDal.List(x => x.SenderMail == p && x.IsRead == false).OrderByDescending(x => x.Id);
        }

        public IOrderedEnumerable<Message> GetListTrashRead(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p && x.IsRead == true && x.IsTrash == true).OrderByDescending(x => x.Id);
        }

        public IOrderedEnumerable<Message> GetListTrashUnRead(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p && x.IsRead == false && x.IsTrash == true).OrderByDescending(x => x.Id);
        }

        public IOrderedEnumerable<Message> GetListDraftRead(string p)
        {
            return _messageDal.List(x => x.SenderMail == p && x.IsRead == true && x.IsDraft == true).OrderByDescending(x => x.Id);
        }

        public IOrderedEnumerable<Message> GetListDraftUnRead(string p)
        {
            return _messageDal.List(x => x.SenderMail == p && x.IsRead == false && x.IsDraft == true).OrderByDescending(x => x.Id);
        }

        public IOrderedEnumerable<Message> GetListStarRead(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p && x.IsRead == true && x.IsStar == true).OrderByDescending(x => x.Id);
        }

        public IOrderedEnumerable<Message> GetListStarUnRead(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p && x.IsRead == false && x.IsStar == true).OrderByDescending(x => x.Id);
        }
    }
}
