using FluentValidation;
using Possumus.Models.Empleo;

namespace Possumus.Api.Validators
{
    public class EmpleoValidator : AbstractValidator<EmpleoRequestModel>
    {
        public EmpleoValidator()
        {
            RuleFor(a => a.Empresa)
                .NotEmpty()
                .WithMessage("EMPRESA no debe quedar en blanco.");

            RuleFor(a => a.Desde)
                .NotEmpty()
                .WithMessage("Desde no debe quedar en blanco");
        }
    }
}
