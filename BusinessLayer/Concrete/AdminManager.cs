using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        SHA1 sha = new SHA1CryptoServiceProvider();

        readonly IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void Add(Admin p)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            var encrypedPassword = crypto.Compute(p.Password);

            var admin = new Admin();

            if (p.Id == 0)
            {
                admin.UserName = p.UserName;
                admin.Password = encrypedPassword;
                admin.Salt = crypto.Salt;
                _adminDal.Insert(p);
            }
        }

        public void Delete(Admin p)
        {
            _adminDal.Delete(p);
        }

        public Admin GetByEmail(string mail)
        {
            return _adminDal.Get(x => x.Email == mail);
        }

        public Admin GetById(int id)
        {
            return _adminDal.Get(x => x.Id == id);
        }

        public Admin GetByName(string username)
        {
            return _adminDal.Get(x => x.UserName == username);
        }

        public List<Admin> GetList()
        {
            return _adminDal.List();
        }

        public bool GetLogin(Admin p)
        {
            //var crypto = new SimpleCrypto.PBKDF2();
            //var encrypedPassword = crypto.Compute(p.Password);

            //enginpolat.com/csharp-ile-hash-islemi/ anlatımı mevcuttur.
            string pass = p.Password;
            string email = p.Email;
            string key = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(pass)));
            string mail = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(email)));
            p.Password = key;
            p.Email = mail;

            var user = _adminDal.Get(x => x.Email == mail && x.Password == key);

            if (user != null)
                return true;
            else
                return false;
        }

        public IOrderedEnumerable<Admin> GetOrderBy()
        {
            return _adminDal.List().OrderByDescending(x => x.Id);
        }

        public void Update(Admin p)
        {
            string pass = p.Password;
            string email = p.Email;
            string key = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(pass)));
            string mail = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(email)));
            p.Password = key;
            p.Email = mail;
            _adminDal.Update(p);
        }
    }
}
