using GestFrigo.Models.Global.Entities;
using GestFrigo.Models.Global.Mappers;
using GestFrigo.Models.Repositories;
using System.Collections.Generic;
using System.Linq;
using Tools.Connections.Database;

namespace GestFrigo.Models.Global.Services
{
    public class ProductService : IProductRepository<Product>
    {
        private readonly IConnection _connection;

        public ProductService(IConnection connection)
        {
            _connection = connection;
        }

        public bool Delete(int id, int userId)
        {
            Command command = new Command("CSP_DeleteProduct");
            command.AddParameter("Id", id);
            command.AddParameter("UserId", userId);

            return _connection.ExecuteNonQuery(command) == 1;
        }

        public IEnumerable<Product> Get(int userId)
        {
            Command command = new Command("SELECT Id, Name, UserId FROM Product WHERE UserId = @UserId", false);
            command.AddParameter("UserId", userId);

            return _connection.ExecuteReader(command, dr => dr.ToProduct());
        }

        public Product Get(int id, int userId)
        {
            Command command = new Command("SELECT Id, Name, UserId FROM Product WHERE Id = @Id AND UserId = @UserId", false);
            command.AddParameter("Id", id);
            command.AddParameter("UserId", userId);

            return _connection.ExecuteReader(command, dr => dr.ToProduct()).SingleOrDefault();
        }

        public bool Insert(Product entity)
        {
            Command command = new Command("CSP_AddProduct");
            command.AddParameter("Name", entity.Name);
            command.AddParameter("UserId", entity.UserId);

            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool ProductInUse(int id, int userId)
        {
            Command command = new Command("Select Count(*) From [Content] Where ProductId = @ProductId AND UserId = @UserId;", false);
            command.AddParameter("ProductId", id);
            command.AddParameter("UserId", userId);

            int count = (int)_connection.ExecuteScalar(command);
            return count != 0;
        }

        public bool ProductNotExists(string name, int userId)
        {
            Command command = new Command("Select Count(Name) From [Product] Where Name = @Name AND UserId = @UserId;", false);
            command.AddParameter("Name", name);
            command.AddParameter("UserId", userId);

            int count = (int)_connection.ExecuteScalar(command);
            return count == 0;
        }

        public bool Update(int id, Product entity)
        {
            Command command = new Command("CSP_UpdateProduct");
            command.AddParameter("ProductId", id);
            command.AddParameter("Name", entity.Name);
            command.AddParameter("UserId", entity.UserId);

            return _connection.ExecuteNonQuery(command) == 1;
        }
    }
}
