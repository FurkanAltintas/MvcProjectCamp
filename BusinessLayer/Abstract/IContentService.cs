using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using EntityLayer.Dto;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        IOrderedEnumerable<Content> GetList();
        List<Content> GetByList(int id);
        Content GetById(int id);
        List<Content> GetWriter(int id);
        List<Content> GetHeading(int id);
        List<ContentChart> GetChart();
        IOrderedEnumerable<Content> GetSearch(string search);
        IOrderedEnumerable<Content> GetOrderList(int? id);
        void Add(Content p);
        void Update(Content p);
        void Delete(Content p);
    }
}