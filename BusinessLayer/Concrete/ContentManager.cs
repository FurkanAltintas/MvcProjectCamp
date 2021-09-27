using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        readonly IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void Add(Content p)
        {
            _contentDal.Insert(p);
        }

        public void Update(Content p)
        {
            _contentDal.Update(p);
        }

        public void Delete(Content p)
        {
            _contentDal.Delete(p);
        }

        public Content GetById(int id)
        {
            return _contentDal.Get(x => x.Id == id);
        }

        public List<Content> GetList()
        {
            return _contentDal.List();
        }

        public List<Content> GetWriter(int id)
        {
            return _contentDal.List(x => x.WriterId == id);
        }

        public List<Content> GetHeading(int id)
        {
            return _contentDal.List(x => x.HeadingId == id);
        }

        public List<Content> GetByList(int id)
        {
            return _contentDal.List(x => x.HeadingId == id);
        }
    }
}
