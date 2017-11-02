using System;
using System.Collections.Generic;

namespace Business
{
    public interface IRepository<T>
    {
        T GetById(Guid id);
        IReadOnlyList<T> GetAll();
        void Add(T entity);
        void Edit(T entity);
        void Delete(Guid id);
    }
}