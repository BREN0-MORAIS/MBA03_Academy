using Academy.PagamentoFaturamento.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.PagamentoFaturamento.Domain.Geteway;

public class GatewayPagamentoSimulado : IGatewayPagamento
{
    public Task<PagamentoResultado> ProcessarPagamento(Guid pedidoId, decimal valor, DadosCartao cartao)
    {
        //// Simula aprovação ou rejeição aleatória
        //var random = new Random();
        ////var aprovado = random.NextDouble() >= 0.2; // 80% chance de sucesso

        //if (aprovado)
        //{
        //    var transacaoId = Guid.NewGuid().ToString().ToUpper();
        //    return Task.FromResult(PagamentoResultado.SucessoResult(transacaoId));
        //}

        return Task.FromResult(PagamentoResultado.Falha("Pagamento recusado pelo banco emissor."));
    }
}
