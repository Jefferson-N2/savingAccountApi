using SavingAccount.Entity.Entities.input;
using SavingAccount.Entity.Entities.output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavingAccount.Domain.structure
{
    public interface IAccountBaseService
    {
            Task<List<EAccountOut>> GetAccount();

            Task<List<EAccountOut>> GetAccountByIdAsync(string id);

            Task<EAccountOut> PostAsync(EAccountIn entity);

            Task<long> GetMaxID();
    }
}
