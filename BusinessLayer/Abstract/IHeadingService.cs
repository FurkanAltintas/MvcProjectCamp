using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using EntityLayer.Dto;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        List<Heading> GetByWriterList(int id);
        List<Heading> GetByList(int id);
        List<HeadingChart> GetChart();
        IOrderedEnumerable<Heading> GetOrderList();
        IOrderedEnumerable<Heading> GetSearch(string search);
        int CategoryCount();
        Heading GetById(int id);
        void Add(Heading p);
        void Update(Heading p);
        void Delete(Heading p);
    }
}