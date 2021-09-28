﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        readonly IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void Add(Heading p)
        {
            _headingDal.Insert(p);
        }

        public int CategoryCount()
        {
            return _headingDal.List(x => x.Category.Name.ToLower() == "yazılım").Count();
        }

        public void Delete(Heading p)
        {
            Update(p);
        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(x => x.Id == id);
        }

        public List<Heading> GetByList(int id)
        {
            return _headingDal.List(x => x.Id == id && x.IsActive == true);
        }

        public List<Heading> GetByWriterList(int id)
        {
            return _headingDal.List(x => x.WriterId == id && x.IsActive == true);
        }

        public List<Heading> GetList()
        {
            return _headingDal.List();
        }

        public IOrderedEnumerable<Heading> GetOrderList()
        {
            return _headingDal.List().OrderByDescending(x => x.Id);
        }

        public IOrderedEnumerable<Heading> GetSearch(string search)
        {
            return _headingDal.List(x => x.Name.ToLower().Contains(search)).OrderByDescending(x => x.Id);
        }

        public void Update(Heading p)
        {
            _headingDal.Update(p);
        }
    }
}
