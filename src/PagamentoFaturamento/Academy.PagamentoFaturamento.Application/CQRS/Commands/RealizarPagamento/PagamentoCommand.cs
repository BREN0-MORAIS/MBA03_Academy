using Academy.PagamentoFaturamento.Domain.Enums;
using MediatR;

namespace Academy.PagamentoFaturamento.Application.CQRS.Commands.RealizarPagamento;

public class RealizarPagamentoCommand : IRequest<string>
{
    public string UserId { get; private set; }
    public Guid MatriculaId { get; private set; }
    public decimal Valor { get; private set; }
    public string NomeTitular { get; private set; }
    public string NumeroCartaoCompleto { get; private set; }
    public string Expiracao { get; private set; }
    public string Cvv { get; private set; }
    public string Bandeira { get; private set; }
    public MeioPagamento MeioPagamento { get; private set; }
    public RealizarPagamentoCommand(Guid matriculaId, decimal valor, string nomeTitular, string numeroCartaoCompleto, string expiracao, string cvv, string bandeira, MeioPagamento meioPagamento, string userId)
    {
        MatriculaId = matriculaId;
        Valor = valor;
        NomeTitular = nomeTitular;
        NumeroCartaoCompleto = numeroCartaoCompleto;
        Expiracao = expiracao;
        Cvv = cvv;
        Bandeira = bandeira;
        MeioPagamento = meioPagamento;
        UserId = userId;
    }
}
