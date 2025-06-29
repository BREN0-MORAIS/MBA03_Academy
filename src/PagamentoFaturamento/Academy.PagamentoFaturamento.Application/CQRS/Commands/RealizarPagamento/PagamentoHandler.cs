using Academy.PagamentoFaturamento.Application.Dto;
using Academy.PagamentoFaturamento.Application.Services.Interfaces;
using MediatR;

namespace Academy.PagamentoFaturamento.Application.CQRS.Commands.RealizarPagamento;

public class RealizarPagamentoHandler : IRequestHandler<RealizarPagamentoCommand, string>
{
    public IPagamentoService _pagamentoService;

    public RealizarPagamentoHandler(IPagamentoService pagamentoService)
    {
        _pagamentoService = pagamentoService;
    }

    public async Task<string> Handle(RealizarPagamentoCommand request, CancellationToken cancellationToken)
    {
        var pagamento = Mapear(request);
        return  await  _pagamentoService.Criar(pagamento, request.UserId);
    }

    public PagamentoDto Mapear(RealizarPagamentoCommand request)
    {
        return new PagamentoDto
        {
             Bandeira = request.Bandeira,
             Cvv = request.Cvv,
             Expiracao = request.Expiracao,
             MatriculaId = request.MatriculaId,
             MeioPagamento = request.MeioPagamento,
             NomeTitular = request.NomeTitular,
             NumeroCartaoCompleto = request.NumeroCartaoCompleto,
             Valor = request.Valor
        };
    }
}
