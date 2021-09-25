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
    public class AbilityManager : IAbilityService
    {
        readonly IAbilityDal _abilityDal;

        public AbilityManager(IAbilityDal abilityDal)
        {
            _abilityDal = abilityDal;
        }

        public void Add(Ability p)
        {
            _abilityDal.Insert(p);
        }

        public void Delete(Ability p)
        {
            _abilityDal.Delete(p);
        }

        public Ability GetById(int id)
        {
            return _abilityDal.Get(x => x.Id == id);
        }

        public List<Ability> GetList()
        {
            return _abilityDal.List();
        }

        public IOrderedEnumerable<Ability> GetOrderList(string p)
        {
            return _abilityDal.List(x => x.Admin.Email == p).OrderByDescending(x=>x.Id);
        }

        public void Update(Ability p)
        {
            _abilityDal.Update(p);
        }
    }
}
