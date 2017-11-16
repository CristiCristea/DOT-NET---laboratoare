using System;
using System.Collections.Generic;
using Data.Domain.Entities;

namespace Data.Domain.Interfaces
{
    public interface IStockRepository
    {
        IReadOnlyList<Stock> GetAll();
        Stock GetById(Guid id);
        void Add(Stock stock);
        void Edit(Stock stock);
        void Delete(Guid id);
    }
}