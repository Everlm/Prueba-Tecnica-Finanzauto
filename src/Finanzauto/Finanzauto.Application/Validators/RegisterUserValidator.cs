using Finanzauto.Application.Dtos.User.Request;
using FluentValidation;

namespace Finanzauto.Application.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserRequestDto>
    {
        public RegisterUserValidator()
        {

            RuleFor(x => x.Email)
                .NotEmpty()
                    .WithMessage("El campo Email es obligatorio.")
                .EmailAddress()
                    .WithMessage("El campo Email debe ser una dirección de correo electrónico válida.");

            RuleFor(x => x.Password)
                .NotEmpty()
                    .WithMessage("El campo Password es obligatorio.")
                .NotNull()
                    .WithMessage("El campo Password no puede ser nulo.")
                .MinimumLength(6)
                    .WithMessage("El campo Password debe tener al menos 6 caracteres.")
                .Matches(@"^(?=.*[A-Z])(?=.*\W)").WithMessage("El campo Password debe contener al menos una mayúscula y un carácter especial.");
        }
    }
}
