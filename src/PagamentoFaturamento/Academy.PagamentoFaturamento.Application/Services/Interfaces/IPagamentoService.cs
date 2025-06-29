using Academy.PagamentoFaturamento.Application.Dto;

namespace Academy.PagamentoFaturamento.Application.Services.Interfaces;

public interface IPagamentoService
{
    Task<string> Criar(PagamentoDto pagamentoDto, string userId);
}
