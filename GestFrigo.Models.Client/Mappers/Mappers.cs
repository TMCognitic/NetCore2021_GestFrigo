using GestFrigo.Models.Client.Entities;
using GUser = GestFrigo.Models.Global.Entities.User;
using GProduct = GestFrigo.Models.Global.Entities.Product;
using GContent = GestFrigo.Models.Global.Entities.Content;

namespace GestFrigo.Models.Client.Mappers
{
    internal static class Mappers
    {
        internal static GUser ToGlobal(this User entity)
        {
            return new GUser() 
            { 
                Id = entity.Id, 
                LastName = entity.LastName, 
                FirstName = entity.FirstName, 
                Email = entity.Email, 
                Passwd = entity.Passwd 
            };
        }

        internal static User ToClient(this GUser entity)
        {
            return new User(entity.Id, entity.LastName, entity.FirstName, entity.Email);
        }

        internal static GProduct ToGlobal(this Product entity)
        {
            return new GProduct()
            {
                Id = entity.Id,
                Name = entity.Name,
                UserId = entity.UserId
            };
        }

        internal static Product ToClient(this GProduct entity)
        {
            return new Product(entity.Id, entity.Name, entity.UserId);
        }

        internal static GContent ToGlobal(this Content entity)
        {
            return new GContent()
            {
                ProductId = entity.ProductId,
                AddedDate = entity.AddedDate,
                ExpirationDate = entity.ExpirationDate,
                UserId = entity.UserId
            };
        }

        internal static Content ToClient(this GContent entity)
        {
            return new Content(entity.Id, entity.ProductId, entity.Name, entity.AddedDate, entity.ExpirationDate, entity.UserId);
        }
    }
}
