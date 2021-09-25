using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetList();
        IOrderedEnumerable<Admin> GetOrderBy();
        Admin GetById(int id);
        Admin GetByName(string username);
        Admin GetByEmail(string mail);
        bool GetLogin(Admin p);
        void Add(Admin p);
        void Update(Admin p);
        void Delete(Admin p);
    }
}
