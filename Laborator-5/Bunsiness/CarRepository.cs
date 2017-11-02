using System;
using System.Collections.Generic;
using System.Linq;
using Context;
using Model;

namespace Bunsiness
{
    public class CarRepository : Repository<Car>
    {
        public CarRepository(IDatabaseService databaseService) : base(databaseService)
        {
        }

        public override IReadOnlyList<Car> GetAll()
        {
            return DatabaseService.Cars.ToList();
        }

        public override Car GetById(Guid id)
        {
            return DatabaseService.Cars.FirstOrDefault(t => t.Id == id);
        }

        public override void Add(Car todo)
        {
            DatabaseService.Cars.Add(todo);
            DatabaseService.SaveChanges();
        }

        public override void Edit(Car todo)
        {
            DatabaseService.Cars.Update(todo);
            DatabaseService.SaveChanges();

        }

        public override void Delete(Guid id)
        {
            var todo = GetById(id);
            DatabaseService.Cars.Remove(todo);
            DatabaseService.SaveChanges();
        }
    }
}
