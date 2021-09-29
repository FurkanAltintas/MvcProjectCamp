using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.Dto;

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

        public IOrderedEnumerable<Content> GetList()
        {
            return _contentDal.List().OrderByDescending(x => x.Id);
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

        public IOrderedEnumerable<Content> GetSearch(string search)
        {
            return _contentDal.List(x => x.Heading.Name.ToLower().Contains(search) || x.Value.ToLower().Contains(search)).OrderByDescending(x => x.Id);

            //if (list == null)
            //{
            //    return GetList();
            //}

            //return list;
        }

        public IOrderedEnumerable<Content> GetOrderList(int? id)
        {
            if (id > 0)
            {
                return _contentDal.List(x => x.HeadingId == id).OrderByDescending(x => x.Id);
            }
            else
            {
                return _contentDal.List().OrderByDescending(x => x.Id);
            }
        }

        public List<ContentChart> GetChart()
        {
            List<ContentChart> contentChart = new List<ContentChart>();

            var list = _contentDal.List();

            foreach (var item in list)
            {
                contentChart.Add(new ContentChart()
                {
                    FullName = item.Writer.Name + " " + item.Writer.SurName,
                    Count = item.Id
                });
            }

            return contentChart;
        }
    }
}
