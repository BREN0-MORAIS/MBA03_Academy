using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PagamentoResultado
{
    public bool Sucesso { get; set; }
    public Guid TransacaoId { get; set; } = Guid.NewGuid();
    public string Mensagem { get; set; }

    public static PagamentoResultado SucessoResult(Guid transacaoId) =>
        new PagamentoResultado { Sucesso = true, TransacaoId = transacaoId, Mensagem = "Pagamento aprovado." };

    public static PagamentoResultado Falha(string mensagem) =>
        new PagamentoResultado { Sucesso = false, TransacaoId = Guid.Empty, Mensagem = mensagem };
}