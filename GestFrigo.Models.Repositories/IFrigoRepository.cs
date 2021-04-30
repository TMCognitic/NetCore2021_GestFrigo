using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestFrigo.Models.Repositories
{
    public interface IFrigoRepository<TEntity>
    {
        IEnumerable<TEntity> Get(int userId);
        bool Insert(TEntity entity);
        bool Delete(long id, int userId);
    }
}
