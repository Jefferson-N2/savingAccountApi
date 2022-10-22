using Microsoft.EntityFrameworkCore;
using SavingAccount.Domain.infraestructure.repository;
using SavingAccount.Domain.Interfaces.infraestructure.client;
using SavingAccount.Entity;
using SavingAccount.Entity.Entities.input;
using SavingAccount.Entity.Entities.output;
using SavingAccount.Entity.Model;
using SavingAccount.Repository.Config.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavingAccount.Repository.repositories.transactions
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AccountDBContext context;

        public TransactionRepository(AccountDBContext context)            
        {
            this.context = context;

        }

        public async Task<ETransactionIn> generateAccount(ETransactionIn transaction)
        {
            var clientResult =  context.Client.Where(a=> transaction.Id.Equals(a.ID_CLIENT)).FirstOrDefault();

            if (clientResult== null)
            {
                context.Client.Add(new ClientModel()
                    {
                        ID_CLIENT = transaction.Id,
                        NAME = transaction.ClientName
                    }
                );
                context.SaveChanges();
            }

            var maxAccount = await context.Account.OrderByDescending(a => a.ID_ACCOUNT).FirstOrDefaultAsync();

            var secuenceAccount = maxAccount == null ? 1 : maxAccount.ID_ACCOUNT;

            string accountNumber = EConstants.ACOUNT_BASE +(100 + secuenceAccount )+"";


            context.Account.Add(
                new AccountModel()
                {
                    ID_CLIENT = transaction.Id,
                    ACCOUNT_NUMBER = accountNumber,
                    ACCOUNT_NAME = EConstants.ACOOUNT_NAME
                }
                );
            context.SaveChanges();
            //context.Dispose();
            
            transaction.Percent *= (transaction.Month / EConstants.INT_YEAR);
            decimal percent = decimal.Round((transaction.Amount * transaction.Percent / 100), EConstants.INT_DECIMAL);
            decimal amountMonth = decimal.Round(((transaction.Amount + percent)/transaction.Month), EConstants.INT_DECIMAL);
            List<BalanceModel> balanceList = new List<BalanceModel>();

            for (int i = 1; i <= transaction.Month; i++) {
                balanceList.Add(
                    new BalanceModel()
                    {
                        ID_CLIENT = transaction.Id,
                        ACCOUNT_NUMBER = accountNumber,
                        CREDIT_VALUE = 0,
                        DEBIT_VALUE = amountMonth,
                        TOTAL_VALUE = decimal.Round((amountMonth * i),EConstants.INT_DECIMAL),
                        Month = i
                    });
                
            }
            context.Balance.AsNoTracking().Take(transaction.Month).ToList();
            context.AddRange(balanceList);
            context.SaveChanges();

            context.Dispose();

            return   transaction;
        }
    }
}
