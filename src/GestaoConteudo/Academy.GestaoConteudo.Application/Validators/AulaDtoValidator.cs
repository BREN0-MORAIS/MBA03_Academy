using Academy.GestaoConteudo.Application.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.GestaoConteudo.Application.Validators
{
    public class AulaDtoValidator : AbstractValidator<AulaDto>
    {
        public AulaDtoValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("O campo título não pode ser vazio.")
                .MinimumLength(5).WithMessage("O campo título não pode ser menor que 5 caracteres.")
                .MaximumLength(50).WithMessage("O campo título tem que ter no mínimo 5 e no máximo 50 caracteres.");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("O campo descrição não pode ser vazio.")
                .MinimumLength(10).WithMessage("O campo descrição não pode ser menor que 10 caracteres.")
                .MaximumLength(500).WithMessage("O campo descrição tem que ter no mínimo 10 e no máximo 500 caracteres.");

            RuleFor(x => x.VideoUrl)
                .NotEmpty().WithMessage("O campo VideoUrl não pode ser vazio.")
                .MinimumLength(10).WithMessage("O campo VideoUrl não pode ser menor que 10 caracteres.");

            RuleFor(x => x.Duracao)
                .NotEmpty().WithMessage("O campo duração não pode ser vazio.")
                .Must(d => d.TotalSeconds > 0).WithMessage("A duração deve ser maior que zero.");

            RuleFor(x => x.Ordem)
                .GreaterThan(0).WithMessage("A ordem deve ser maior que zero.");

            RuleFor(x => x.CursoId)
                .NotEmpty().WithMessage("O campo CursoId não pode ser vazio.");
        }
    }
}
