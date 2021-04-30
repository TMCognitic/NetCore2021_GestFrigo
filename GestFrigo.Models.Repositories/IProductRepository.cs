using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestFrigo.Models.Repositories
{
    public interface IProductRepository<TEntity>
    {
        IEnumerable<TEntity> Get(int userId);
        TEntity Get(int id, int userId);
        bool Insert(TEntity entity);
        bool ProductInUse(int id, int userId);
        bool ProductNotExists(string name, int userId);
        bool Update(int id, TEntity entity);
        bool Delete(int id, int userId);
    }
}
