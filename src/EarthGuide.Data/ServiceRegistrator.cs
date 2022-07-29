using EarthGuide.Core.Interfaces;
using EarthGuide.Data;
using EarthGuide.Data.Db;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthGuide.Data
{
    public static class ServiceRegistrator
    {
        public static void UseInMemoryDb(this IServiceCollection services)
        {
            services.AddSingleton<IRestaurantRepository, InMemory.RestaurantRepository>();
            services.AddSingleton<IUserRepository, InMemory.UserRepository>();
            services.AddSingleton<ISightplaceRepository, InMemory.SightplaceRepository>();
        }

        public static void UseSqliteDb(this IServiceCollection services, string dataSource)
        {
            services.AddSingleton<IDbConnectionFactory>(_ => new SqliteConnectionFactory(dataSource));

            services.AddSingleton<IRestaurantRepository, Dapper.RestaurantRepository>();
            services.AddSingleton<IUserRepository, Dapper.UserRepository>();
            services.AddSingleton<ISightplaceRepository, Dapper.SightplaceRepository>();
        }
    }
}
