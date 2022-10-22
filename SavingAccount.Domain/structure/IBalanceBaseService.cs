using SavingAccount.Entity.Entities.input;
using SavingAccount.Entity.Entities.output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavingAccount.Domain.structure
{
    public interface IBalanceBaseService
    {
            Task<List<EBalanceOut>> GetBalance();

            Task<List<EBalanceOut>> GetBalanceByIdAsync(string id);

            Task<EBalanceOut> PostAsync(EBalanceIn entity);

    }
}
