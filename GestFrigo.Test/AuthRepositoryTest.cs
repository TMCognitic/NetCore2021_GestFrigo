using GestFrigo.Models.Global.Entities;
using GestFrigo.Models.Global.Services;
using GestFrigo.Models.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tools.Connections.Database;
using System.Data.SqlClient;
using System.Data.Common;

namespace GestFrigo.Test
{
    [TestClass]
    public class AuthRepositoryTest
    {
        [TestMethod]
        public void TestRegister1()
        {
            IConnection connection = new Connection(SqlClientFactory.Instance, @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GestFrigo;Integrated Security=True;");
            IAuthRepository<User> repository = new AuthService(connection);

            User user = new User() { LastName = "Person", FirstName = "Michael", Email = "michael.person@cognitic.be", Passwd = "test1234=" };

            bool result = repository.Register(user);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(DbException), AllowDerivedTypes = true)]
        public void TestRegister2()
        {
            IConnection connection = new Connection(SqlClientFactory.Instance, @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GestFrigo;Integrated Security=True;");
            IAuthRepository<User> repository = new AuthService(connection);

            User user = new User() { LastName = "Person", FirstName = "Michael", Email = "michael.person@cognitic.be", Passwd = "test1234=" };

            bool result = repository.Register(user);
        }
    }
}
