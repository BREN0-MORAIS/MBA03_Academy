using Academy.GestaoConteudo.Application.CQRS.Commands.AtualizarCurso;
using Academy.GestaoConteudo.Application.DTOs;
using Academy.GestaoConteudo.Application.Services.Interfaces;
using MediatR;

namespace Academy.GestaoConteudo.Application.CQRS.Commands.AtualizarAula;

public class AtualizarAulaHandler : IRequestHandler<AtualizarAulaCommand, Guid>
{
    private readonly IAulaService _aulaService;

    public AtualizarAulaHandler(IAulaService aulaService)
    {
        _aulaService = aulaService;
    }

    public async Task<Guid> Handle(AtualizarAulaCommand request, CancellationToken cancellationToken)
    {
        var aulaDto = Mapear(request);

        var aulaId = await _aulaService.Atualizar(request.Id, aulaDto);

        return aulaId;
    }

    public AulaDto Mapear(AtualizarAulaCommand request)
    {
        var aulaDto = new AulaDto
        {
            Titulo = request.Titulo,
            Descricao = request.Descricao,
            VideoUrl = request.VideoUrl,
            Duracao = request.Duracao,
            Ordem = request.Ordem,
            CursoId = request.CursoId
        };

        return aulaDto;
    }

}
