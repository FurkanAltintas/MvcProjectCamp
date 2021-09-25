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
    public class ContactManager : IContactService
    {
        readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public List<Contact> GetList()
        {
            return _contactDal.List();
        }

        public Contact GetById(int id)
        {
            return _contactDal.Get(x => x.Id == id);
        }

        public void Add(Contact p)
        {
            _contactDal.Insert(p);
        }

        public void Update(Contact p)
        {
            _contactDal.Update(p);
        }

        public void Delete(Contact p)
        {
            _contactDal.Delete(p);
        }

        public IOrderedEnumerable<Contact> OrderByList()
        {
            return _contactDal.List().OrderByDescending(x => x.Id);
        }

        public IOrderedEnumerable<Contact> OrderByListRead()
        {
            return _contactDal.List(x => x.IsRead == true).OrderByDescending(x => x.Id);
        }

        public IOrderedEnumerable<Contact> OrderByListUnread()
        {
            return _contactDal.List(x => x.IsRead == false).OrderByDescending(x => x.Id);
        }
    }
}
