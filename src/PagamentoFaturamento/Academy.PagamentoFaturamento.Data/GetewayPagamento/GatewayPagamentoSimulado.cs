using Academy.Core.Exceptions;
using Academy.PagamentoFaturamento.Domain.ValueObjects;

namespace Academy.PagamentoFaturamento.Domain.Geteway;

public class GatewayPagamentoSimulado : IGatewayPagamento
{
    public Task<PagamentoResultado> ProcessarPagamento(Guid matriculaId, decimal valorPago, decimal valorCurso, DadosCartao cartao)
    {
        if (valorPago < 0) throw new DomainException("O valor não pode ser menor que 0");
        if (valorPago != valorCurso) return Task.FromResult(PagamentoResultado.Falha("Pagamento recusado pelo banco emissor."));
        if (cartao is null) return Task.FromResult(PagamentoResultado.Falha("Dados do cartão estão invalidos"));
        var transacaoId = Guid.NewGuid();
        return Task.FromResult(PagamentoResultado.SucessoResult(transacaoId));
    }
}
