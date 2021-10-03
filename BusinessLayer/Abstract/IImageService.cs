using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IImageService
    {
        List<Image> GetList();
        IOrderedEnumerable<Image> GetListOrderBy();
        Image GetById(int id);
        List<Image> GetCategoryId(int id);
        void Add(Image p);
        void Update(Image p);
        void Delete(Image p);
    }
}
