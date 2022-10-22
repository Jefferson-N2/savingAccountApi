using FluentValidation;
using SavingAccount.Entity;
using SavingAccount.Entity.Entities.input;

namespace SavingAccount.Infraestructure.validations
{
    public class ClientValidations : AbstractValidator<EClientIn>
    {
        public ClientValidations()
        {
            RuleFor(a=>a.Id).Cascade(CascadeMode.StopOnFirstFailure).Matches(EConstants.REGEX_INT);
            RuleFor(a => a.Id).Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("vacio")
            .NotNull().WithMessage("Nulo")
            .MaximumLength(10).WithMessage(EConstants.Max_MESSAGE_CI)
            .MinimumLength(10).WithMessage(EConstants.Max_MESSAGE_CI);
            
            RuleFor(a => a.ClientName).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("vacio")
                .NotNull().WithMessage("Nulo")
                .MinimumLength(2).WithMessage(" nombre");
                        
        }
    }
}
