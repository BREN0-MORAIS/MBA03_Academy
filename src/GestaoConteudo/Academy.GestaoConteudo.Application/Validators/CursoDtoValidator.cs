using Academy.GestaoConteudo.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.GestaoConteudo.Application.Validators
{
    public class CursoDTOValidator : AbstractValidator<CursoDto>
    {
        public CursoDTOValidator()
        {
            RuleFor(x => x.Titulo)
                    .NotEmpty()
                    .MinimumLength(5)
                    .MaximumLength(50);


            RuleFor(x => x.Descricao)
                    .NotEmpty()
                    .MinimumLength(10)
                    .MaximumLength(500);


            RuleFor(x => x.Status)
                .NotNull();

            RuleFor(x => x.Valor)
                .GreaterThan(10).WithMessage("O valor deve ser maior que 5.");

            RuleFor(x => x.Objetivo)
               .NotEmpty()
               .MinimumLength(10)
               .MaximumLength(500);

            RuleFor(x => x.PreRequisitos)
               .NotEmpty()
               .MinimumLength(10)
               .MaximumLength(500);
        }
    }
}
