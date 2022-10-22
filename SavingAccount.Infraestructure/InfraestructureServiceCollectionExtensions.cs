using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SavingAccount.Domain.Interfaces.infraestructure.client;
using SavingAccount.Infraestructure.infraestructure;
using SavingAccount.Repository;
using SavingAccount.Domain.infraestructure.repository;
using SavingAccount.Repository.repositories.client;
using SavingAccount.Repository.repositories.Account;
using SavingAccount.Repository.repositories.Balance;
using SavingAccount.Repository.repositories.transactions;

namespace SavingAccount.Infraestructure
{
    public static class InfraestructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepository();
            services.AddScoped<ITransactionInfraestructure, TransactionInfraestructure>();
            services.AddScoped<IClientInfraestructure, ClientInfraestructure>();
            services.AddScoped<IAccountInfraestructure, AccountInfraestructure>();
            services.AddScoped<IBalanceInfraestructure, BalanceInfraestructure>();
            

            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IBalanceRepository, BalanceRepository>();
            



            return services;
        }
    }
}
