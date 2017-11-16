using System;
using Business;
using Microsoft.AspNetCore.Mvc;
using Data.Domain.Entities;
using Data.Domain.Interfaces;
using MVCApplication.DTOs;

namespace MVCApplication.Controllers
{
    public class StocksController : Controller
    {
        private readonly StockRepository _repository;

        public StocksController(IStockRepository repository)
        {
            _repository = (StockRepository) repository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        public IActionResult Details(Guid id)
        {
            var stock = _repository.GetById(id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Code,Date,EndPrice,StartPrice")] CreateStock stock)
        {
            if (ModelState.IsValid)
            {
                var entity = Stock.Create(stock.Name, stock.Code, stock.Date, stock.StartPrice, stock.EndPrice);
                _repository.Add(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(stock);
        }

        public IActionResult Edit(Guid id)
        {
            var stock = _repository.GetById(id);
            if (stock == null)
            {
                return NotFound();
            }
            return View(stock);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Name,Code,Date,EndPrice,StartPrice")] CreateStock stock)
        {
            if (ModelState.IsValid)
            {
                if (_repository.GetById(id) != null)
                {
                    var entity = _repository.GetById(id);
                    entity.Update(stock.Name, stock.Code, stock.Date, stock.StartPrice, stock.EndPrice);
                    _repository.Edit(entity);
                }
                else
                {
                    return NotFound();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid id)
        {
            var stock = _repository.GetById(id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            if (_repository.GetById(id) != null)
            {
                _repository.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

/*
        private bool StockExists(Guid id)
        {
            return _repository.GetAll().Count > 0;
        }
*/
    }
}