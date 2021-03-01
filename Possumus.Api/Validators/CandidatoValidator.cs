using FluentValidation;
using Possumus.Models.Candidato;

namespace Possumus.Api.Validators
{
    public class CandidatoValidator : AbstractValidator<CandidatoRequestModel>
    {
        public CandidatoValidator()
        {
            RuleFor(a => a.Nombre)
                .NotEmpty()
                .WithMessage("Nombre no debe quedar en blanco.");

            RuleFor(a => a.Apellido)
                .NotEmpty()
                .WithMessage("Apellido no debe quedar en blanco");

            RuleFor(a => a.Email)
                .NotEmpty()
                    .WithMessage("Email no debe quedar en blanco")
                .EmailAddress()
                    .WithMessage("Email inválido");

            RuleForEach(x => x.Empleos).SetValidator(new EmpleoValidator());
               
        }
    }
}
