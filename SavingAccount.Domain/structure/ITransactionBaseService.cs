using SavingAccount.Entity.Entities.input;
using System.Threading.Tasks;

namespace SavingAccount.Domain.structure
{
    public interface ITransactionBaseService
    {
        Task<ETransactionIn> generateAccount(ETransactionIn transaction);
    }
}
