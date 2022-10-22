using SavingAccount.Entity.Entities.input;
using System.Threading.Tasks;

namespace SavingAccount.Domain.validations
{
    public interface IClientValidations 
    {
        Task<(bool cumple, string codigo, string mensaje)> 
            validateInput(EClientIn entrada);

        Task<(bool cumple, string codigo, string mensaje)>
            validateInput(string param);
    }
}
