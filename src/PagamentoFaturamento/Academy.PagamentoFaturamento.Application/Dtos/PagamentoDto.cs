using Academy.PagamentoFaturamento.Domain.Enums;

namespace Academy.PagamentoFaturamento.Application.Dto;

public class PagamentoDto
{
    public Guid MatriculaId { get; set; }
    public decimal Valor { get; set; }
    public string NomeTitular { get; set; }
    public string NumeroCartaoCompleto { get; set; }
    public string Expiracao { get; set; }
    public string Cvv { get; set; }
    public string Bandeira { get; set; }
    public MeioPagamento MeioPagamento { get; set; }

}
