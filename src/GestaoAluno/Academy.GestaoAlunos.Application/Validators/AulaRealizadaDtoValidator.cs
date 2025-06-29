using Academy.GestaoAlunos.Application.Dtos;
using FluentValidation;

namespace Academy.GestaoAlunos.Application.Validators;

public class AulaRealizadaDtoValidator : AbstractValidator<AulaRealizadaDto>
{
    public AulaRealizadaDtoValidator()
    {
        RuleFor(x => x.MatriculaId)
         .NotEmpty()
         .WithMessage("O campo MatriculaId é obrigatório.");

        RuleFor(x => x.AulaId)
       .NotEmpty()
       .WithMessage("O campo AulaId é obrigatório.");
    }

}
