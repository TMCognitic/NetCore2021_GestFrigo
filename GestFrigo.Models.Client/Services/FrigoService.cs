using GestFrigo.Models.Client.Entities;
using GestFrigo.Models.Client.Mappers;
using GContent = GestFrigo.Models.Global.Entities.Content;
using GestFrigo.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;


namespace GestFrigo.Models.Client.Services
{
    public class FrigoService : IFrigoRepository<Content>
    {
        private readonly IFrigoRepository<GContent> _globalRepository;

        public FrigoService(IFrigoRepository<GContent> globalRepository)
        {
            _globalRepository = globalRepository;
        }

        public bool Delete(long id, int userId)
        {
            return _globalRepository.Delete(id, userId);
        }

        public IEnumerable<Content> Get(int userId)
        {
            return _globalRepository.Get(userId).Select(c => c.ToClient());
        }

        public bool Insert(Content entity)
        {
            return _globalRepository.Insert(entity.ToGlobal());
        }
    }
}
