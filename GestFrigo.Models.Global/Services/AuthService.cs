using GestFrigo.Models.Global.Entities;
using GestFrigo.Models.Global.Mappers;
using GestFrigo.Models.Repositories;
using System.Linq;
using Tools.Connections.Database;

namespace GestFrigo.Models.Global.Services
{
    public class AuthService : IAuthRepository<User>
    {
        private readonly IConnection _connection;

        public AuthService(IConnection connection)
        {
            _connection = connection;
        }

        public User CheckUser(string email, string passwd)
        {
            Command command = new Command("CSP_CheckUser");
            command.AddParameter("Email", email);
            command.AddParameter("Passwd", passwd);

            return _connection.ExecuteReader(command, dr => dr.ToUser()).SingleOrDefault();
        }

        public bool EmailNotExists(string email)
        {
            Command command = new Command("Select Count(Email) From [User] Where Email = @Email;", false);
            command.AddParameter("Email", email);
            int count = (int)_connection.ExecuteScalar(command);
            return count == 0;
        }

        public bool Register(User entity)
        {
            Command command = new Command("CSP_RegisterUser");
            command.AddParameter("LastName", entity.LastName);
            command.AddParameter("FirstName", entity.FirstName);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("Passwd", entity.Passwd);
            return _connection.ExecuteNonQuery(command) == 1;
        }
    }
}
