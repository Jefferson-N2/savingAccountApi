using SavingAccount.Entity.Entities.input;
using SavingAccount.Entity.Entities.output;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SavingAccount.Domain.structure
{ 
    public interface IClientBaseService
    {
        Task<List<EClientOut>> GetClient();

        Task<EClientOut> GetClientByIdAsync(string id);

        Task<EClientOut> PostAsync(EClientIn entity );


    }
}
