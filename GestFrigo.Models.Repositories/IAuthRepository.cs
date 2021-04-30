using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestFrigo.Models.Repositories
{
    public interface IAuthRepository<TEntity>
    {
        TEntity CheckUser(string email, string passwd);
        bool EmailNotExists(string email);
        bool Register(TEntity entity);

    }
}
