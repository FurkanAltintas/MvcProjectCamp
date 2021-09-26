using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dto;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        SHA1 sha = new SHA1CryptoServiceProvider();

        readonly IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }
        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(x => x.Id == id);
        }

        public void Add(Writer p)
        {
            _writerDal.Insert(p);
        }

        public void Update(Writer p)
        {
            _writerDal.Update(p);
        }

        public void Delete(Writer p)
        {
            _writerDal.Update(p);
        }

        public int WriterCountA()
        {
            //yazar adında 'a' harfi geçen yazar sayısı
            //var writer = c.Writer.Where(x => x.Name.Contains("a")).Count();
            return _writerDal.List(x => x.Name.ToLower().Contains("a")).Count();
        }

        public bool GetLogin(Writer p)
        {
            var user = _writerDal.Get(x => x.Mail == p.Mail && x.Password == p.Password);

            if (user != null)
                return true;
            else
                return false;
        }

        public Writer GetByName(string username)
        {
            return _writerDal.Get(x => x.FullName == username);
        }

        public Writer GetByEmail(string mail)
        {
            return _writerDal.Get(x => x.Mail == mail);
        }

        public IEnumerable<int> GetByEmailID(string mail)
        {
            return _writerDal.List(x => x.Mail == mail).Select(y => y.Id);
        }
    }
}
