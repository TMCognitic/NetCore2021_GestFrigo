using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestFrigo.Models.Client.Entities
{
    public class Content
    {
        public long Id { get; private set; }
        public int ProductId { get; private set; }
        public string Name { get; private set; }
        public DateTime AddedDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public int UserId { get; private set; }

        public Content(int productId, DateTime addedDate, DateTime expirationDate, int userId)
        {
            ProductId = productId;
            AddedDate = addedDate;
            ExpirationDate = expirationDate;
            UserId = userId;
        }

        internal Content(long id, int productId, string name, DateTime addedDate, DateTime expirationDate, int userId)
            : this (productId, addedDate, expirationDate, userId)
        {
            Id = id;
            Name = name;
        }
    }
}
