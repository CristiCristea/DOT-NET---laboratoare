using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Bunsiness;
using Microsoft.AspNetCore.Mvc;
using Model;
using Presentation.Models;

namespace Presentation.Controllers
{
    [Route("api/car")]
    public class CarController : Controller
    {
        private readonly Repository<Car> _repository;
        public CarController(Repository<Car> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public void AddCar([FromBody]CreateTodoModel car)
        {
            var entity = Car.Create(car.Name, car.IsElectric);
            _repository.Add(entity);
            Response.StatusCode = 200;
        }

        [HttpPut("{id}")]
        public void EditCar(Guid id, [FromBody]UpdateTodoModel car)
        {
            var entity = _repository.GetById(id);
            if (entity != null)
            {
                entity.Update(car.Name, car.IsElectric);
                _repository.Edit(entity);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
            }

        }

        [HttpDelete("{id}")]
        public void DeleteCar(Guid id)
        {
            var entity = _repository.GetById(id);
            if (entity != null)
            {
                _repository.Delete(id);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }

        [HttpGet]
        public IEnumerable<Car> GetAllCars()
        {
            return _repository.GetAll();
        }

        [HttpGet("{id}")]
        public Car GetCarById(Guid id)
        {
            var entity = _repository.GetById(id);
            if (entity != null)
            {
                return _repository.GetById(id);
            }
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return null;
        }

        [HttpGet("electric")]
        public IEnumerable<Car> GetElectricCars()
        {
            var electricCars = _repository.GetAll().Where(car => car.IsElectric);
            return electricCars;
           
        }
    }
}
