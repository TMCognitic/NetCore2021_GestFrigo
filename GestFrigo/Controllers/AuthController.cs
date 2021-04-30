using GestFrigo.Infrastructure;
using GestFrigo.Models.Client.Entities;
using GestFrigo.Models.Forms;
using GestFrigo.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestFrigo.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthRepository<User> _repository;

        public AuthController()
        {
            _repository = RessourceLocator.Instance.AuthRepository;
        }

        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        //renvoyer le formulaire
        public ActionResult Login()
        {
            return View();
        }

        //Traiter le formulaire
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginForm form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User u = _repository.CheckUser(form.Email, form.Passwd);
                    if(!(u is null))
                    {
                        SessionManager.User = u;
                        return RedirectToAction("Index", "Frigo");
                    }

                    ViewBag.ErrorMessage = "Erreur Login ou Mot de passe";
                }
                return View(form);            
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [AuthRequired]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        //renvoyer le formulaire
        public ActionResult Register()
        {
            return View();
        }

        //Traiter le formulaire
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterForm form)
        {
            if(ModelState.IsValid)
            {
                if(_repository.Register(new User(form.LastName, form.FirstName, form.Email, form.Passwd)))
                {
                    return RedirectToAction("Login");
                }
            }
            return View(form);
        }        
    }
}