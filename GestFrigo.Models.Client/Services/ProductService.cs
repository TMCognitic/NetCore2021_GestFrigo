using GProduct = GestFrigo.Models.Global.Entities.Product;
using GestFrigo.Models.Client.Entities;
using GestFrigo.Models.Repositories;
using System.Collections.Generic;
using System.Linq;
using GestFrigo.Models.Client.Mappers;

namespace GestFrigo.Models.Client.Services
{
    public class ProductService : IProductRepository<Product>
    {
        private readonly IProductRepository<GProduct> _globalRepository;

        public ProductService(IProductRepository<GProduct> globalRepository)
        {
            _globalRepository = globalRepository;
        }

        public bool Delete(int id, int userId)
        {
            return _globalRepository.Delete(id, userId);
        }

        public IEnumerable<Product> Get(int userId)
        {
            return _globalRepository.Get(userId).Select(p => p.ToClient());
        }

        public Product Get(int id, int userId)
        {
            return _globalRepository.Get(id, userId)?.ToClient();
        }

        public bool Insert(Product entity)
        {
            return _globalRepository.Insert(entity.ToGlobal());
        }

        public bool ProductInUse(int id, int userId)
        {
            return _globalRepository.ProductInUse(id, userId);
        }

        public bool ProductNotExists(string name, int userId)
        {
            return _globalRepository.ProductNotExists(name, userId);
        }

        public bool Update(int id, Product entity)
        {
            return _globalRepository.Update(id, entity.ToGlobal());
        }
    }
}
