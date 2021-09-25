﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        int CategoryCount();
        Heading GetById(int id);
        void Add(Heading p);
        void Update(Heading p);
        void Delete(Heading p);
    }
}