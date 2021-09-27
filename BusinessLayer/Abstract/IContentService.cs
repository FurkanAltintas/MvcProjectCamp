using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetByList(int id);
        Content GetById(int id);
        List<Content> GetWriter(int id);
        List<Content> GetHeading(int id);
        void Add(Content p);
        void Update(Content p);
        void Delete(Content p);
    }
}