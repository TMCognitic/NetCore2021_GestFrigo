using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestFrigo.Models.Client.Entities
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public int UserId { get; private set; }

        public Product(string name, int userId)
        {
            Name = name;
            UserId = userId;
        }

        internal Product(int id, string name, int userId)
            : this (name, userId)
        {
            Id = id;
        }
    }
}
