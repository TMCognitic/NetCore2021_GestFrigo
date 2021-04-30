using GestFrigo.Models.Global.Entities;
using GestFrigo.Models.Global.Mappers;
using GestFrigo.Models.Repositories;
using System;
using System.Collections.Generic;
using Tools.Connections.Database;

namespace GestFrigo.Models.Global.Services
{
    public class FrigoService : IFrigoRepository<Content>
    {
        private readonly IConnection _connection;

        public FrigoService(IConnection connection)
        {
            _connection = connection;
        }

        public bool Delete(long id, int userId)
        {
            Command command = new Command("CSP_DeleteContent");
            command.AddParameter("ContentId", id);
            command.AddParameter("UserId", userId);

            return _connection.ExecuteNonQuery(command) == 1;
        }

        public IEnumerable<Content> Get(int userId)
        {   
            Command command = new Command("Select Id, ProductId, Name, AddedDate, ExpirationDate, UserId From [V_Content] Where UserId = @UserId Order By ExpirationDate;", false);
            command.AddParameter("UserId", userId);
            return _connection.ExecuteReader(command, dr => dr.ToContent());
        }

        public bool Insert(Content entity)
        {
            Command command = new Command("CSP_AddContent");
            command.AddParameter("ProductId", entity.ProductId);
            command.AddParameter("AddedDate", entity.AddedDate);
            command.AddParameter("ExpirationDate", entity.ExpirationDate);            
            command.AddParameter("UserId", entity.UserId);

            return _connection.ExecuteNonQuery(command) == 1;
        }
    }
}
