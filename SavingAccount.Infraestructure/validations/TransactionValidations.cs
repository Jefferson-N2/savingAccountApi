using FluentValidation;
using SavingAccount.Entity;
using SavingAccount.Entity.Entities.input;

namespace SavingAccount.Infraestructure.validations
{
    public class TransactionValidations : AbstractValidator<ETransactionIn>
    {
        public TransactionValidations()
        {

        
            RuleFor(a => a.Id).Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage(EConstants.EMPTY_MESSAGE)
            .NotNull().WithMessage(EConstants.NULL_MESSAGE)
            .MaximumLength(10).WithMessage(EConstants.Max_MESSAGE_CI)
            .MinimumLength(10).WithMessage(EConstants.Max_MESSAGE_CI)
            .Matches(EConstants.REGEX_INT).WithMessage(EConstants.INT_MESSAGE);

            RuleFor(a => a.ClientName).Cascade(CascadeMode.StopOnFirstFailure)                
            .NotEmpty().WithMessage(EConstants.EMPTY_MESSAGE)
            .NotNull().WithMessage(EConstants.NULL_MESSAGE)
            .Matches(EConstants.REGEX_STRING).WithMessage(EConstants.STRG_MESSAGE);


            RuleFor(a => a.Amount)
                .GreaterThan(99)
                .WithMessage(EConstants.AMOUNT_MESSAGE)
                .NotEmpty().WithMessage(EConstants.EMPTY_MESSAGE)
                .NotNull().WithMessage(EConstants.NULL_MESSAGE);

            RuleFor(a => a.Month)
            .GreaterThan(0)
            .NotEmpty().WithMessage(EConstants.EMPTY_MESSAGE);

            RuleFor(a => a.Percent)
            .GreaterThan(0)
            .NotEmpty().WithMessage(EConstants.EMPTY_MESSAGE);

        }
    }
}
