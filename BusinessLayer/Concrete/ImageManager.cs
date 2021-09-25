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
    public class ImageManager : IImageService
    {
        readonly IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public List<Image> GetList()
        {
            return _imageDal.List();
        }

        public IOrderedEnumerable<Image> GetListOrderBy()
        {
            return _imageDal.List().OrderByDescending(x => x.Id);
        }

        public Image GetById(int id)
        {
            return _imageDal.Get(x => x.Id == id);
        }

        public void Add(Image p)
        {
            _imageDal.Insert(p);
        }

        public void Update(Image p)
        {
            _imageDal.Update(p);
        }

        public void Delete(Image p)
        {
            _imageDal.Delete(p);
        }
    }
}
