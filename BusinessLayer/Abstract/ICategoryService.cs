using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using EntityLayer.Dto;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();
        List<CategoryChart> GetChart();
        int StatusTrue();
        int StatusFalse();
        Category GetById(int id);
        void Add(Category p);
        void Update(Category p);
        void Delete(Category p);
    }
}
