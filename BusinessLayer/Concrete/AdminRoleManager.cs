using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminRoleManager : IAdminRoleService
    {
        IAdminRoleDal _adminRoleDal;

        public AdminRoleManager(IAdminRoleDal adminRoleDal)
        {
            _adminRoleDal = adminRoleDal;
        }

        public void Add(AdminRole p)
        {
            _adminRoleDal.Insert(p);
        }

        public void Delete(AdminRole p)
        {
            _adminRoleDal.Delete(p);
        }

        public AdminRole GetById(int id)
        {
            return _adminRoleDal.Get(X => X.Id == id);
        }

        public List<AdminRole> GetList()
        {
            return _adminRoleDal.List();
        }

        public void Update(AdminRole p)
        {
            _adminRoleDal.Update(p);
        }
    }
}
