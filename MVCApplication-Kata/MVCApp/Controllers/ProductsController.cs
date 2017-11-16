using System;
using Business;
using Microsoft.AspNetCore.Mvc;
using Data.Domain.Entities;
using Data.Domain.Interfaces;
using MVCApp.DTOs;

namespace MVCApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = (ProductRepository) repository;
        }

        // GET: Products
        public IActionResult Index()
        {
            return View(_repository.Getall());
        }

        // GET: Products/Details/5
        public IActionResult Details(Guid id)
        {
            var product = _repository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Description,Price")] CreateProduct product)
        {
            if (ModelState.IsValid)
            {
                var entity = Product.Create(product.Description, product.Price);
                _repository.Add(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(Guid id)
        {
            var product = _repository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Description,Price")] CreateProduct product)
        {
            if (ModelState.IsValid)
            {
                if (_repository.GetById(id) != null)
                {
                    var entity = _repository.GetById(id);
                    entity.Update(product.Description, product.Price);
                    _repository.Edit(entity);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(Guid id)
        {
            var product = _repository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
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
        private bool ProductExists(Guid id)
        {
            return _repository.Getall().Count > 0;
        }
*/
    }
}