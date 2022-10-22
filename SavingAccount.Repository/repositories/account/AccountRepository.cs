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

namespace SavingAccount.Repository.repositories.Account
{

    public class AccountRepository : IAccountRepository
    {
        private readonly AccountDBContext context;

        public AccountRepository(AccountDBContext context)
        {
            this.context = context;

        }


        public async Task<List<EAccountOut>> GetAccount()
        {
            var query =   context.Account;

            if (query == null)
                throw new Exception("No existen registros");

            return await query.Select(b =>
                new EAccountOut()
                {Id=b.ID_ACCOUNT,
                    AccountNumber = b.ACCOUNT_NUMBER,
                    AccountName = b.ACCOUNT_NAME,
                    CiClient = b.ID_CLIENT

                }
            ).ToListAsync();
        }

        public async Task<List<EAccountOut>> GetAccountByIdAsync(string id)
        {
            var query =  context.Account.Where(b=> b.ID_CLIENT == id);

            if (query == null)
                throw new Exception("Cuenta no existente");

            return await query.Select(a => new EAccountOut()
            {
                Id = a.ID_ACCOUNT,
                AccountNumber = a.ACCOUNT_NUMBER,
                AccountName = a.ACCOUNT_NAME,
                CiClient = a.ID_CLIENT


            }).ToListAsync();
          ;
        }

        public async Task<long> GetMaxID()
        {
            var maxRow = await context.Account.Include(a=>a.ID_ACCOUNT).MaxAsync();
            
            return  maxRow.ID_ACCOUNT;
        }

        public async Task<EAccountOut> PostAsync(EAccountIn entity)
        {
            var query =
                await context.Account.Where(b => b.ACCOUNT_NUMBER == entity.AccountNumber).SingleOrDefaultAsync();
            
            if (query != null)
                throw new ArgumentException("Cuenta: "+ entity.AccountNumber +  " Cliente: " + entity.CiClient);

            context.Account.Add(new AccountModel()
            {                
                ID_CLIENT = entity.CiClient,
                ACCOUNT_NUMBER = entity.AccountNumber,
                ACCOUNT_NAME = entity.AccountName

            });

            context.SaveChanges();
            context.Dispose();

            return new EAccountOut()
            {
                AccountNumber = entity.AccountNumber,
                AccountName = entity.AccountName,
                CiClient = entity.CiClient


            };
        }

    }
}
