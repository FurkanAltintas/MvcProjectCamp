using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using EntityLayer.Dto;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        public void Add(Category p)
        {
            _categoryDal.Insert(p);
        }

        public void Update(Category p)
        {
            _categoryDal.Update(p);
        }

        public void Delete(Category p)
        {
            _categoryDal.Delete(p);
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(x => x.Id == id);
        }


        public int StatusTrue()
        {
            return _categoryDal.List(x => x.IsActive == true).Count;
        }

        public int StatusFalse()
        {
            return _categoryDal.List(x => x.IsActive == false).Count;
        }

        public List<CategoryChart> GetChart()
        {
            List<CategoryChart> categoryChart = new List<CategoryChart>();

            var list = _categoryDal.List();

            foreach (var item in list)
            {
                categoryChart.Add(new CategoryChart()
                {
                    Name = item.Name,
                    Count = list.Count()
                });
            }

            return categoryChart;
        }
    }
}
