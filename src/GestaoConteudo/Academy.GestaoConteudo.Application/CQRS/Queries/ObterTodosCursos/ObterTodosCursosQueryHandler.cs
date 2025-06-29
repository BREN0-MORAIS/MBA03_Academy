using Academy.GestaoConteudo.Application.Dtos;
using Academy.GestaoConteudo.Application.Services.Interfaces;
using Academy.GestaoConteudo.Domain.Enums;
using MediatR;

namespace Academy.GestaoConteudo.Application.CQRS.Queries.ObterTodosCursos;

public class ObterTodosCursosQueryHandler : IRequestHandler<ObterTodosCursosQuery, IEnumerable<CursoDto>>
{
    private readonly ICursoService _cursoService;

    public ObterTodosCursosQueryHandler(ICursoService cursoService)
    {
        _cursoService = cursoService;
    }

    public async Task<IEnumerable<CursoDto>> Handle(ObterTodosCursosQuery request, CancellationToken cancellationToken)
    {
        if (request.Status == (int)CursoStatus.Ativo)
            return await _cursoService.ObterTodos(status: CursoStatus.Ativo);

        if (request.Status == (int)CursoStatus.Inatvo)
            return await _cursoService.ObterTodos(status: CursoStatus.Inatvo);

        return await _cursoService.ObterTodos();
    }
}
