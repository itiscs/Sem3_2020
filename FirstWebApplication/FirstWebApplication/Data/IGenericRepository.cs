﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApplication.Data
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Add(T entity);
        void Remove(T entity);        

    }
}
