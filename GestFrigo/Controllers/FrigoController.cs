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
    public class FrigoController : Controller
    {
        private readonly IProductRepository<Product> _productRepository;
        private readonly IFrigoRepository<Content> _frigoRepository;

        public FrigoController()
        {
            _productRepository = RessourceLocator.Instance.ProductRepository;
            _frigoRepository = RessourceLocator.Instance.FrigoRepository;
        }

        public ActionResult Index()
        {
            return View(_frigoRepository.Get(SessionManager.User.Id).Select(c => new ViewContent() { Id = c.Id, Name = c.Name, AddedDate = c.AddedDate, ExpirationDate = c.ExpirationDate }));
        }

        public ActionResult AddContent()
        {
            AddContentForm form = new AddContentForm();
            form.Products = new List<SelectListItem>(_productRepository.Get(SessionManager.User.Id).Select(p => new SelectListItem() { Text = p.Name, Value = p.Id.ToString() }));
            return PartialView("_AddContent", form);
        }

        [HttpPost]
        public ActionResult AddContent(AddContentForm form)
        {
            if(ModelState.IsValid)
            {
                _frigoRepository.Insert(new Content(form.ProductId, form.AddedDate, form.ExpirationDate, SessionManager.User.Id));
                form = new AddContentForm();
                //pour la redirection
                ViewBag.Added = true;
            }
            //recharger la liste des produits
            form.Products = new List<SelectListItem>(_productRepository.Get(SessionManager.User.Id).Select(p => new SelectListItem() { Text = p.Name, Value = p.Id.ToString() }));
           
            return PartialView("_AddContent", form);
        }

        public ActionResult Delete(long id)
        {
            _frigoRepository.Delete(id, SessionManager.User.Id);
            return RedirectToAction("Index");
        }
    }
}