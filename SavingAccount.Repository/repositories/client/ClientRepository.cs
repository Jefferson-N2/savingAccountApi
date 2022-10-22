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

namespace SavingAccount.Repository.repositories.client
{

    public class ClientRepository : IClientRepository
    {
        private readonly AccountDBContext context;

        public ClientRepository(AccountDBContext context)
        {
            this.context = context;

        }

        public async Task<List<EClientOut>> GetClient()
        {
            var query =   context.Client.Distinct();

            if (query == null)
                throw new Exception("No existen clientes");

            return await query.Select(b =>
            new EClientOut()
            {
                Id = b.ID_CLIENT,
                Name = b.NAME,
                CreationDate = b.CEATION_DATE,
                accountList = b.ACCOUNT_LIST.Select(a => new EAccountOut
                {
                    Id = a.ID_ACCOUNT,
                    AccountNumber=a.ACCOUNT_NUMBER,
                    AccountName = a.ACCOUNT_NAME



                }).ToList()

            }
        ).ToListAsync();
        }

        public async Task<EClientOut> GetClientByIdAsync(string id)
        {
            var query =  await context.Client.Where(b=> b.ID_CLIENT == id).SingleOrDefaultAsync();

            if (query == null)
                return null;


            return query == null ? null : new EClientOut()
            {
                Id = query.ID_CLIENT,
                Name = query.NAME,
                CreationDate = query.CEATION_DATE            
            };
        }

        public async Task<EClientOut> PostAsync(EClientIn entity)
        {
            var query = await context.Client.Where(b => b.ID_CLIENT == entity.Id).SingleOrDefaultAsync();

            if (query != null)
                throw new ArgumentException("Cliente ya se encuentra reagistrado: " + entity.Id);

            var date = DateTime.Now;
            context.Client.Add(new ClientModel()
            {
                ID_CLIENT = entity.Id,
                NAME = entity.ClientName,
                CEATION_DATE = date

            });

            context.SaveChanges();
            context.Dispose();

            return new EClientOut()
            {
                Id = entity.Id,
                Name = entity.ClientName,
                CreationDate = date
            };
        }

    }
}
