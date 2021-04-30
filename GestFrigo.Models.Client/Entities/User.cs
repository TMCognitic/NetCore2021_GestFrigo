using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestFrigo.Models.Client.Entities
{
    public class User
    {
        public int Id { get; private set; }
        internal string LastName { get; private set; }
        internal string FirstName { get; private set; }
        public string FullName { get { return $"{LastName} {FirstName}"; } }
        public string Email { get; set; }
        public string Passwd { get; private set; }

        public User(string lastName, string firstName, string email, string passwd)
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Passwd = passwd;
        }

        internal User(int id, string lastName, string firstName, string email)
            : this(lastName, firstName, email, null)
        {
            Id = id;
        }
    }
}
