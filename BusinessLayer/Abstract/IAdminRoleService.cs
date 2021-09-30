using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminRoleService
    {
        List<AdminRole> GetList();
        AdminRole GetById(int id);
        void Add(AdminRole p);
        void Update(AdminRole p);
        void Delete(AdminRole p);
    }
}
