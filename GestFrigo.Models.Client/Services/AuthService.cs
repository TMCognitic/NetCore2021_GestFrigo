using GestFrigo.Models.Client.Entities;
using GestFrigo.Models.Client.Mappers;
using GUser = GestFrigo.Models.Global.Entities.User;
using GestFrigo.Models.Repositories;


namespace GestFrigo.Models.Client.Services
{
    public class AuthService : IAuthRepository<User>
    {
        private readonly IAuthRepository<GUser> _globalRepository;

        public AuthService(IAuthRepository<GUser> globalRepository)
        {
            _globalRepository = globalRepository;
        }

        public User CheckUser(string email, string passwd)
        {
            return _globalRepository.CheckUser(email, passwd)?.ToClient();
        }

        public bool EmailNotExists(string email)
        {
            return _globalRepository.EmailNotExists(email);
        }

        public bool Register(User entity)
        {
            return _globalRepository.Register(entity.ToGlobal());
        }
    }
}
