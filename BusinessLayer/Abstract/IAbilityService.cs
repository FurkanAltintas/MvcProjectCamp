using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAbilityService
    {
        List<Ability> GetList();
        IOrderedEnumerable<Ability> GetOrderList(string p);
        Ability GetById(int id);
        void Add(Ability p);
        void Update(Ability p);
        void Delete(Ability p);
    }
}
