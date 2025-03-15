using Finanzauto.Application.Dtos.Auth.Request;
using FluentValidation;

namespace Finanzauto.Application.Validators
{
    public class LoginValidator : AbstractValidator<LoginRequestDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("El nombre es obligatorio.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("El nombre es obligatorio.");
        }
    }
}
