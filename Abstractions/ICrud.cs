﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions
{
    public interface ICrud<T>
    {
        T Save(T entity);
        Task<IEnumerable<T>> GetAll();
        T GetById(int id);
        void Delete(int id);
        void Update(T entity);
        Task<IEnumerable<T>> PaginatedGetAll(IPaginationFilter filter);
        int Count();
    }
}
