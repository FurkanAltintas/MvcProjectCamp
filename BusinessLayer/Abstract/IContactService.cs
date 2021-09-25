using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();
        IOrderedEnumerable<Contact> OrderByList();
        IOrderedEnumerable<Contact> OrderByListRead();
        IOrderedEnumerable<Contact> OrderByListUnread();
        Contact GetById(int id);
        void Add(Contact p);
        void Update(Contact p);
        void Delete(Contact p);
    }
}