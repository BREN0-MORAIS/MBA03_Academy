using Academy.Core.DomainObjects;
using Academy.Core.DomainObjects.Validations;

namespace Academy.PagamentoFaturamento.Domain.ValueObjects;

public class DadosCartao 
{
    public string NomeTitular { get; }
    public string NumeroCartaoCompleto { get; } 
    public string Expiracao { get; } 
    public string Cvv { get; }
    public string Bandeira { get; }

    public string Ultimos4Digitos => NumeroCartaoCompleto.Length >= 4
        ? NumeroCartaoCompleto[^4..]
        : NumeroCartaoCompleto;

    public DadosCartao(string nomeTitular, string numeroCartao, string expiracao, string cvv, string bandeira)
    {
        Validacoes.ValidarSeVazio(nomeTitular, "O nome do titular é obrigatório.");
        Validacoes.ValidarSeVazio(numeroCartao, "O número do cartão é obrigatório.");
        Validacoes.ValidarTamanho(numeroCartao, 13, 19, "O número do cartão deve ter entre 13 e 19 dígitos.");
        Validacoes.ValidarSeVazio(expiracao, "A data de expiração é obrigatória.");
        Validacoes.ValidarSeDiferente(@"^(0[1-9]|1[0-2])\/\d{2}$", expiracao, "A data de expiração deve estar no formato MM/YY.");
        Validacoes.ValidarSeVazio(cvv, "O código de segurança é obrigatório.");
        Validacoes.ValidarTamanho(cvv, 3, 4, "O código de segurança deve ter 3 ou 4 dígitos.");
        Validacoes.ValidarSeVazio(bandeira, "A bandeira do cartão é obrigatória.");

        NomeTitular = nomeTitular;
        NumeroCartaoCompleto = numeroCartao;
        Expiracao = expiracao;
        Cvv = cvv;
        Bandeira = bandeira;
    }
}
