using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IImageCategoryService
    {
        List<ImageCategory> GetList();
        ImageCategory GetById(int id);
        void Add(ImageCategory p);
        void Update(ImageCategory p);
        void Delete(ImageCategory p);
    }
}
