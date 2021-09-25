using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetList();
        //List<Message> GetListInbox(); //sırasız liste
        IOrderedEnumerable<Message> OrderByList(string p); //sıralı liste
        IOrderedEnumerable<Message> GetListInbox(string p);
        IOrderedEnumerable<Message> GetListInboxRead(string p);
        IOrderedEnumerable<Message> GetListInboxUnRead(string p);
        IOrderedEnumerable<Message> GetListSendbox(string p);
        IOrderedEnumerable<Message> GetListSendboxRead(string p);
        IOrderedEnumerable<Message> GetListSendboxUnRead(string p);
        IOrderedEnumerable<Message> GetListTrash(string p);
        IOrderedEnumerable<Message> GetListTrashRead(string p);
        IOrderedEnumerable<Message> GetListTrashUnRead(string p);
        IOrderedEnumerable<Message> GetListDraft(string p);
        IOrderedEnumerable<Message> GetListDraftRead(string p);
        IOrderedEnumerable<Message> GetListDraftUnRead(string p);
        IOrderedEnumerable<Message> GetListStar(string p);
        IOrderedEnumerable<Message> GetListStarRead(string p);
        IOrderedEnumerable<Message> GetListStarUnRead(string p);

        Message GetById(int id);
        void Add(Message p);
        void Update(Message p);
        void Delete(Message p);

    }
}
