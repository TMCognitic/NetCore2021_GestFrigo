using GestFrigo.Models.Client.Entities;
using GestFrigo.Models.Client.Services;
using GE = GestFrigo.Models.Global.Entities;
using GS = GestFrigo.Models.Global.Services;
using GestFrigo.Models.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Tools.Connections.Database;
using Tools.Patterns.DependencyInjection;

namespace GestFrigo.Infrastructure
{
    public class RessourceLocator : LocatorBase
    {
        #region Singleton
        private static RessourceLocator _instance;
        public static RessourceLocator Instance
        {
            get { return _instance ?? (_instance = new RessourceLocator()); }
        }

        private RessourceLocator()
        {

        }
        #endregion

        protected override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConnection>(sp => new Connection(SqlClientFactory.Instance, ConfigurationManager.ConnectionStrings["GestFrigoDB"].ConnectionString));
            services.AddSingleton<IAuthRepository<GE.User>, GS.AuthService>();
            services.AddSingleton<IAuthRepository<User>, AuthService>();
            services.AddSingleton<IProductRepository<GE.Product>, GS.ProductService>();
            services.AddSingleton<IProductRepository<Product>, ProductService>();
            services.AddSingleton<IFrigoRepository<GE.Content>, GS.FrigoService>();
            services.AddSingleton<IFrigoRepository<Content>, FrigoService>();
        }

        public IAuthRepository<User> AuthRepository
        {
            get { return Container.GetService<IAuthRepository<User>>(); }
        }

        public IProductRepository<Product> ProductRepository
        {
            get { return Container.GetService<IProductRepository<Product>>(); }
        }

        public IFrigoRepository<Content> FrigoRepository
        {
            get { return Container.GetService<IFrigoRepository<Content>>(); }
        }
    }
}