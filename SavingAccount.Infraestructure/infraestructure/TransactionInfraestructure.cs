using SavingAccount.Domain.infraestructure.repository;
using SavingAccount.Domain.Interfaces.infraestructure.client;
using SavingAccount.Entity.Entities.input;
using SavingAccount.Infraestructure.validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SavingAccount.Infraestructure.infraestructure
{
    public class TransactionInfraestructure : ITransactionInfraestructure
    {
        private readonly ITransactionRepository repository;

        public TransactionInfraestructure(ITransactionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ETransactionIn> generateAccount(ETransactionIn transaction)
        {
            TransactionValidations val = new TransactionValidations();
            var resul = val.Validate(transaction);
            if (!resul.IsValid)
                throw new Exception(resul.Errors.First().ErrorMessage);

            return await repository.generateAccount(transaction);

        }
    }
}
