using Microsoft.EntityFrameworkCore;
using SavingAccount.Domain.infraestructure.repository;
using SavingAccount.Entity.Entities.input;
using SavingAccount.Entity.Entities.output;
using SavingAccount.Entity.Model;
using SavingAccount.Repository.Config.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavingAccount.Repository.repositories.Balance
{

    public class BalanceRepository : IBalanceRepository
    {
        private readonly AccountDBContext context;

        public BalanceRepository(AccountDBContext context)
        {
            this.context = context;

        }

        public async Task<List<EBalanceOut>> GetBalance()
        {
            var query =   context.Balance;

            return await query.Select(b =>
                new EBalanceOut()
                {
                    AccountNumber = b.ACCOUNT_NUMBER,
                    IdClient = b.ID_CLIENT,
                    DebitValue = b.DEBIT_VALUE,
                    CreditValue = b.CREDIT_VALUE,
                    TotalValue = b.TOTAL_VALUE

                }
            ).ToListAsync();
        }

        public async Task<List<EBalanceOut>> GetBalanceByIdAsync(string id)
        {
            var query =  context.Balance.Where(b=> b.ACCOUNT_NUMBER == id)
                .OrderBy(a=>a.Month);
            
            if (query == null)
            {
                throw new Exception($"No existen Registros: {id}");
            }
            
            return await query.Select(a => new EBalanceOut()
            {
                AccountNumber = a.ACCOUNT_NUMBER,
                IdClient = a.ID_CLIENT,
                Month = a.Month,
                DebitValue = a.DEBIT_VALUE,
                CreditValue = a.CREDIT_VALUE,
                TotalValue = a.TOTAL_VALUE

            }).ToListAsync();
        }

        public async Task<EBalanceOut> PostAsync(EBalanceIn entity)
        {
            var query = context.Balance.Where(b => b.ACCOUNT_NUMBER == entity.AccountNumber).FirstOrDefault();

            await context.AddAsync(
                new BalanceModel()
                {
                    ID_CLIENT = entity.IdClient,
                    ACCOUNT_NUMBER = entity.IdClient,
                    CREDIT_VALUE = entity.CreditValue,
                    DEBIT_VALUE = entity.DebitValue,
                    TOTAL_VALUE = entity.TotalValue,
                    Month = entity.Month
                });

            await context.SaveChangesAsync();

          return  new EBalanceOut()
            {
                AccountNumber = entity.AccountNumber,
                IdClient = entity.IdClient,
                DebitValue = entity.DebitValue,
                CreditValue = entity.CreditValue,
                TotalValue = entity.TotalValue,
                Month = entity.Month

            };
        }


    }
}
