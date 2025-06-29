using Academy.GestaoConteudo.Application.Dtos;
using Academy.GestaoConteudo.Application.Services.Interfaces;
using MediatR;

namespace Academy.GestaoConteudo.Application.CQRS.Queries.ObterAulasPorCursoId;

public class ObterAulasPorCursoIdHandler :   IRequestHandler<ObterAulasPorCursoIdQuery, CursoDto>
{
    private readonly ICursoService cursoService;
    public ObterAulasPorCursoIdHandler(ICursoService cursoService)
    {
        this.cursoService = cursoService;
    }

    public async Task<CursoDto> Handle(ObterAulasPorCursoIdQuery request, CancellationToken cancellationToken)
    {
        var aulasPorCursoId = await cursoService.ObterPorId(request.CursoId, x => x.Aulas);

        return aulasPorCursoId;
    }
}



