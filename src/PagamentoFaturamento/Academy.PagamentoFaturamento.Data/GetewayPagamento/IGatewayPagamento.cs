using Academy.PagamentoFaturamento.Domain.ValueObjects;
using System.Threading.Tasks;

namespace Academy.PagamentoFaturamento.Domain.Geteway;

public interface IGatewayPagamento
{
    Task<PagamentoResultado> ProcessarPagamento(Guid matriculaId, decimal valorPago, decimal valorCurso, DadosCartao cartao);
}
