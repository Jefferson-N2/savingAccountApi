using SavingAccount.Domain.infraestructure.repository;
using SavingAccount.Domain.Interfaces.infraestructure.client;
using SavingAccount.Entity.Entities.input;
using SavingAccount.Entity.Entities.output;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SavingAccount.Infraestructure.infraestructure
{
    public class AccountInfraestructure : IAccountInfraestructure
    {
        public readonly IAccountRepository repository ;

        public AccountInfraestructure(IAccountRepository repository)
        {
            this.repository = repository;
            
        }

        public Task<bool> DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EAccountOut>> GetAccount()
        {

            return await repository.GetAccount();
        }

        public async Task<List<EAccountOut>> GetAccountByIdAsync(string id)
        {

            return await repository.GetAccountByIdAsync(id);
        }

        public async Task<long> GetMaxID()
        {
            return await repository.GetMaxID();
        }

        public async Task<EAccountOut> PostAsync(EAccountIn entity)
        {
            return await repository.PostAsync(entity);
        }

        public Task<EAccountOut> PutAsync(EAccountIn entity)
        {
            throw new NotImplementedException();
        }
    }
}
