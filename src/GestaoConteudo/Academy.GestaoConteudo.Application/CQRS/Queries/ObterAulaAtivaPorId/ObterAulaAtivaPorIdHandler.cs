using Academy.GestaoConteudo.Application.Dtos;
using Academy.GestaoConteudo.Application.Services.Interfaces;
using MediatR;

namespace Academy.GestaoConteudo.Application.CQRS.Queries.ObterAulaAtivaPorId;

public class ObterAulaAtivaPorIdHandler : IRequestHandler<ObterAulaAtivaPorIdQuery, AulaDto>
{
    private readonly IAulaService _aulaService;

    public ObterAulaAtivaPorIdHandler(IAulaService aulaService)
    {
        _aulaService = aulaService;
    }

    public async Task<AulaDto> Handle(ObterAulaAtivaPorIdQuery request, CancellationToken cancellationToken)
    {
        return await _aulaService.ObterPorId(request.AulaId);
    }
}
