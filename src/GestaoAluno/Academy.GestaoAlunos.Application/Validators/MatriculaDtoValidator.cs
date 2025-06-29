using Academy.GestaoAlunos.Application.Dtos;
using FluentValidation;

namespace Academy.GestaoAlunos.Application.Validators;

public class MatriculaDtoValidator :  AbstractValidator<MatriculaDto>
{
    public MatriculaDtoValidator()
    {
        RuleFor(x => x.CursoId)
        .NotEmpty()
        .WithMessage("O campo CursoId é obrigatório.");

        RuleFor(x => x.UserId)
       .NotEmpty()
       .WithMessage("O campo UserId é obrigatório.");    
    }
}
