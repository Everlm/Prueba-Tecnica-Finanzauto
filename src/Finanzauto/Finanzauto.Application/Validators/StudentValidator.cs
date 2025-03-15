using Finanzauto.Application.Dtos.Student.Request;
using FluentValidation;

namespace Finanzauto.Application.Validators
{
    public class StudentValidator : AbstractValidator<StudentRequestDto>
    {
        public StudentValidator()
        {
            RuleFor(s => s.DocumentNumber)
                .NotNull()
                    .WithMessage("El número de documento es requerido.")
                .GreaterThan(0)
                    .WithMessage("El número de documento debe ser mayor a cero.")
                .Must(x => x.ToString().Length is >= 1 and <= 10)
                    .WithMessage("El número de documento debe tener entre 1 y 10 dígitos.");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                    .WithMessage("El nombre es obligatorio.")
            .MinimumLength(2)
                .WithMessage("El nombre debe tener al menos 2 caracteres.")
            .MaximumLength(50)
                .WithMessage("El nombre no puede tener más de 50 caracteres.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                    .WithMessage("El apellido es obligatorio.")
                .MinimumLength(2)
                    .WithMessage("El apellido debe tener al menos 2 caracteres.")
                .MaximumLength(50)
                    .WithMessage("El apellido no puede tener más de 50 caracteres.");

            RuleFor(x => x.State)
                .InclusiveBetween(0, 1)
                    .WithMessage("El estado debe ser 0 (inactivo) o 1 (activo).");
        }
    }
}
