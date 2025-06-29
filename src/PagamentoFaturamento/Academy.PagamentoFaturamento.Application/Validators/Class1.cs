using Academy.PagamentoFaturamento.Application.Dto;
using FluentValidation;

namespace Academy.PagamentoFaturamento.Application.Validators;

public class PagamentoDtoValidator : AbstractValidator<PagamentoDto>
{
    public PagamentoDtoValidator()
    {
        RuleFor(x => x.MatriculaId)
            .NotEmpty().WithMessage("A matrícula é obrigatória.");

        RuleFor(x => x.NomeTitular)
            .NotEmpty().WithMessage("O nome do titular é obrigatório.")
            .MinimumLength(3).WithMessage("O nome deve ter ao menos 3 caracteres.")
            .MaximumLength(100).WithMessage("O nome não pode ultrapassar 100 caracteres.");

        RuleFor(x => x.NumeroCartaoCompleto)
            .NotEmpty().WithMessage("O número do cartão é obrigatório.")
            .CreditCard().WithMessage("O número do cartão não é válido.")
            .Length(13, 19).WithMessage("O número do cartão deve conter entre 13 e 19 dígitos.");

        RuleFor(x => x.Expiracao)
            .NotEmpty().WithMessage("A data de expiração é obrigatória.")
            .Matches(@"^(0[1-9]|1[0-2])\/\d{2}$").WithMessage("A data deve estar no formato MM/YY.");

        RuleFor(x => x.Cvv)
            .NotEmpty().WithMessage("O código de segurança é obrigatório.")
            .Length(3, 4).WithMessage("O CVV deve ter 3 ou 4 dígitos.")
            .Matches(@"^\d+$").WithMessage("O CVV deve conter apenas números.");

        RuleFor(x => x.Bandeira)
            .NotEmpty().WithMessage("A bandeira do cartão é obrigatória.")
            .MaximumLength(20).WithMessage("A bandeira não pode ultrapassar 20 caracteres.");
    }
}
