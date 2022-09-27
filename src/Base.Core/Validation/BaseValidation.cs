using FluentValidation;
using Base.Core.ValueObject;

namespace Base.Core.Validation
{
    public class BaseValidation : AbstractValidator<Aggregate.Base>
    {
        public BaseValidation()
        {
            ValidateCpf();
        }

        protected void ValidateCpf()
        {
            RuleFor(data => data.Cpf)
                .Custom((value, context) =>
                {
                    var isValid = new Cpf(value).IsValid;
                    if (!isValid)
                        context.AddFailure("Cpf", "Invalid CPF.");
                });
        }
    }
}
