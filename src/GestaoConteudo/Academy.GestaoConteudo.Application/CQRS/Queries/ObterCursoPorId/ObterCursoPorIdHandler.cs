using Academy.GestaoConteudo.Application.CQRS.Queries.ObterTodosCursos;
using Academy.GestaoConteudo.Application.DTOs;
using Academy.GestaoConteudo.Application.Services.Interfaces;
using MediatR;

namespace Academy.GestaoConteudo.Application.CQRS.Queries.ObterCursoPorId;

public class ObterCursoPorIdHandler : IRequestHandler<ObterCursoPorIdQuery, CursoDto>
{
    private readonly ICursoService _cursoService;

    public ObterCursoPorIdHandler(ICursoService cursoService)
    {
        _cursoService = cursoService;
    }

    public async Task<CursoDto> Handle(ObterCursoPorIdQuery request, CancellationToken cancellationToken)
    {
       return await _cursoService.ObterPorId(request.Id, c=> c.Aulas);
    }
}
