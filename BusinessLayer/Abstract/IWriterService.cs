﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();
        Writer GetById(int id);
        bool GetLogin(Writer p);
        int WriterCountA();
        void Add(Writer p);
        void Update(Writer p);
        void Delete(Writer p);
    }
}