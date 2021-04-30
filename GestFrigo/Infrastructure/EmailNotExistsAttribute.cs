using GestFrigo.Models.Client.Entities;
using GestFrigo.Models.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestFrigo.Infrastructure
{
    public class EmailNotExistsAttribute : ValidationAttribute
    {
        public EmailNotExistsAttribute()
        {
            ErrorMessage = "Cette adresse email est déjà utilisée";
        }

        public override bool IsValid(object value)
        {
            string email = value as string;

            if (email is null)
                return false;

            IAuthRepository<User> repository = RessourceLocator.Instance.AuthRepository;
            return repository.EmailNotExists((string)value);
        }
    }
}