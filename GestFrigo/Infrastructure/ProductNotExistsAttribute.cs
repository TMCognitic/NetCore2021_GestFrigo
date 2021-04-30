using GestFrigo.Models.Client.Entities;
using GestFrigo.Models.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestFrigo.Infrastructure
{
    public class ProductNotExistsAttribute : ValidationAttribute
    {
        public ProductNotExistsAttribute()
        {
            ErrorMessage = "Vous avez déjà créé ce produit...";
        }

        public override bool IsValid(object value)
        {
            string email = value as string;

            if (email is null)
                return false;

            IProductRepository<Product> repository = RessourceLocator.Instance.ProductRepository;
            return repository.ProductNotExists((string)value, SessionManager.User.Id);
        }
    }
}