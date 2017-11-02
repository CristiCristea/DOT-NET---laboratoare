using System;
using System.Collections.Generic;
using Context;

namespace Bunsiness
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IDatabaseService DatabaseService;

        protected Repository(IDatabaseService databaseService)
        {
            DatabaseService = databaseService;
        }

        public abstract T GetById(Guid id);

        public abstract IReadOnlyList<T> GetAll();

        public abstract void Add(T entity);

        public abstract void Edit(T entity);

        public abstract void Delete(Guid id);
    }
}
