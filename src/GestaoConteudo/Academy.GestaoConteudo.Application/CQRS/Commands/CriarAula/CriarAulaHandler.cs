using Academy.GestaoConteudo.Application.CQRS.Commands.CriarCurso;
using Academy.GestaoConteudo.Application.DTOs;
using Academy.GestaoConteudo.Application.Services.Implements;
using Academy.GestaoConteudo.Application.Services.Interfaces;
using MediatR;

namespace Academy.GestaoConteudo.Application.CQRS.Commands.CriarAula;

public class CriarAulaHandler : IRequestHandler<CriarAulaCommand, Guid>
{
    private readonly IAulaService _aulaService;

    public CriarAulaHandler(IAulaService aulaService)
    {
        _aulaService = aulaService;
    }

    public async Task<Guid> Handle(CriarAulaCommand request, CancellationToken cancellationToken)
    {
        var aulaDto = Mapear(request);
        var aulaId = await _aulaService.Criar(aulaDto);

        return aulaId;
    }

    public AulaDto Mapear(CriarAulaCommand request)
    {
        var cursoDto = new AulaDto
        {
            Titulo = request.Titulo,
            Descricao = request.Descricao,
            CursoId = request.CursoId,
            Duracao = request.Duracao,  
            Ordem = request.Ordem,
            VideoUrl = request.VideoUrl 
        };

        return cursoDto;
    }
}
