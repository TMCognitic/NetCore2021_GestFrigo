using GestFrigo.Infrastructure;
using GestFrigo.Models.Client.Entities;
using GestFrigo.Models.Forms;
using GestFrigo.Models.Repositories;
using GestFrigo.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestFrigo.Controllers
{
    [AuthRequired]
    public class ProductController : Controller
    {
        private readonly IProductRepository<Product> _repository;

        public ProductController()
        {
            _repository = RessourceLocator.Instance.ProductRepository;
        }

        // GET: Product
        public ActionResult Index()
        {
            return View(_repository.Get(SessionManager.User.Id).Select(p => new ViewProduct() { Id = p.Id, Name = p.Name }));
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(AddProductForm form)
        {
            if(ModelState.IsValid)
            {
                _repository.Insert(new Product(form.Name, SessionManager.User.Id));
                return RedirectToAction("Index");
            }

            return View(form);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            if (_repository.ProductInUse(id, SessionManager.User.Id))
                return RedirectToAction("Index");

            Product product = _repository.Get(id, SessionManager.User.Id);
            if(product is null)
                return RedirectToAction("Index");

            return View(new UpdateProductForm() { Name = product.Name });
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UpdateProductForm form)
        {
            if (_repository.ProductInUse(id, SessionManager.User.Id))
            {
                ViewBag.ErrorMessage("Ce produit est dans votre frigo...");
                return View(form);
            }

            if (ModelState.IsValid)
            {
                _repository.Update(id, new Product(form.Name, SessionManager.User.Id));
                return RedirectToAction("Index");
            }
            return View(form);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            if (_repository.ProductInUse(id, SessionManager.User.Id))
            {
                ViewBag.ErrorMessage("Ce produit est dans votre frigo...");
                return View();
            }

            _repository.Delete(id, SessionManager.User.Id);
            return RedirectToAction("Index");
        }
    }
}
