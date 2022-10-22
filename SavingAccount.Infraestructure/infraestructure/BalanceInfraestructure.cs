using SavingAccount.Domain.infraestructure.repository;
using SavingAccount.Domain.Interfaces.infraestructure.client;
using SavingAccount.Domain.structure;
using SavingAccount.Entity.Entities.input;
using SavingAccount.Entity.Entities.output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavingAccount.Infraestructure.infraestructure
{
    public class BalanceInfraestructure : IBalanceInfraestructure
    {
        public readonly IBalanceRepository  repository ;
        //private readonly IBalanceValidations validations;
       

        public BalanceInfraestructure(IBalanceRepository repository)
        {
            this.repository = repository;
          //  this.validations = validations;
            
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EBalanceOut>> GetBalance()
        {
            return await repository.GetBalance();
        }

        public async Task<List<EBalanceOut>> GetBalanceByIdAsync(string id)
        {

            return await repository.GetBalanceByIdAsync(id);
        }

        public async Task<EBalanceOut> PostAsync(EBalanceIn entity)
        {
            return await repository.PostAsync(entity);
        }

        public Task<EBalanceOut> PutAsync(EBalanceIn entity)
        {
            throw new NotImplementedException();
        }


    }
}
