
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SavingAccount.Entity;
using SavingAccount.Repository.Config.Persistence;
using System;

namespace SavingAccount.Repository
{
    public static class RepositoryServiceCollectionExtensions
    {
        private static readonly string stringConnection;

        static RepositoryServiceCollectionExtensions(){
            RepositoryServiceCollectionExtensions.stringConnection = EConstants.CONNECTION_BD;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddDbContext<AccountDBContext>(options => options.UseSqlServer(stringConnection));
            return services;
        }
    }

}
