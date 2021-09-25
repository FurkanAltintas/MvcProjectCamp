using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ImageCategoryManager : IImageCategoryService
    {
        readonly IImageCategoryDal _imageCategoryDal;

        public ImageCategoryManager(IImageCategoryDal imageCategoryDal)
        {
            _imageCategoryDal = imageCategoryDal;
        }

        public List<ImageCategory> GetList()
        {
           return  _imageCategoryDal.List();
        }

        public ImageCategory GetById(int id)
        {
            return _imageCategoryDal.Get(x => x.Id == id);
        }

        public void Add(ImageCategory p)
        {
            _imageCategoryDal.Insert(p);
        }

        public void Update(ImageCategory p)
        {
            _imageCategoryDal.Update(p);
        }

        public void Delete(ImageCategory p)
        {
            _imageCategoryDal.Delete(p);
        }
    }
}
