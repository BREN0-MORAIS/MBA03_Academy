using Academy.Core.DomainObjects.Validations;
using Academy.Core.Entities;
using Academy.Core.Interfaces;
using Academy.PagamentoFaturamento.Domain.Enums;
using Academy.PagamentoFaturamento.Domain.ValueObjects;

namespace Academy.PagamentoFaturamento.Domain.Entities;

public class Pagamento : EntidadeBase, IAggregateRoot
{
    public Guid MatriculaId { get; private set; }
    public decimal Valor { get; private set; }
    public StatusPagamento StatusPagamento { get; private set; }
    public MeioPagamento MeioPagamento { get; private set; }
    public Guid TransacaoId { get; private set; }
    public string CartaoFinal { get; private set; }     
    public string Bandeira { get; private set; }       
    public DateTime DataPagamento { get; private set; }
    public string MensagemGateway { get; private set; }

    public Pagamento() { }

    public Pagamento(
        Guid matriculaId,
        decimal valor,
        MeioPagamento meioPagamento,
        DadosCartao dadosCartao,
        Guid transacaoId,
        string mensagemGateway)
    {
   
        Validacoes.ValidarSeIgual(matriculaId, Guid.Empty, "Matrícula inválida.");
        Validacoes.ValidarSeMenorQue(valor, 0, "O valor do pagamento deve ser maior que zero.");
        Validacoes.ValidarSeNulo(dadosCartao, "Os dados do cartão são obrigatórios.");
        Validacoes.ValidarSeNulo(transacaoId, "Transação inválida.");
        Validacoes.ValidarSeVazio(mensagemGateway, "Mensagem do gateway é obrigatória.");

        Validacoes.ValidarSeVazio(dadosCartao.NumeroCartaoCompleto, "O número do cartão é obrigatório.");


        MatriculaId = matriculaId;
        Valor = valor;
        MeioPagamento = meioPagamento;
        CartaoFinal = dadosCartao.Ultimos4Digitos; 
        TransacaoId = transacaoId;
        MensagemGateway = mensagemGateway;

        StatusPagamento = StatusPagamento.Pendente;
        DataPagamento = DateTime.UtcNow;
    }

    public void Confirmar()
    {
        StatusPagamento = StatusPagamento.Confirmado;
    }

    public void Recusar(string mensagem)
    {
        StatusPagamento = StatusPagamento.Recusado;
        MensagemGateway = mensagem;
    }
}
