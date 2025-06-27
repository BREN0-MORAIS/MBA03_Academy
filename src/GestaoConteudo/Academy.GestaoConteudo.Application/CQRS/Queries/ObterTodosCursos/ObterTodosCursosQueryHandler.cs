using Academy.GestaoConteudo.Application.DTOs;
using Academy.GestaoConteudo.Application.Services.Interfaces;
using MediatR;

namespace Academy.GestaoConteudo.Application.CQRS.Queries.ObterTodosCursos
{
    public class ObterTodosCursosQueryHandler : IRequestHandler<ObterTodosCursosQuery, IEnumerable<CursoDto>>
    {
        private readonly ICursoService _cursoService;

        public ObterTodosCursosQueryHandler(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        public async Task<IEnumerable<CursoDto>> Handle(ObterTodosCursosQuery request, CancellationToken cancellationToken)
        {
            var cursos = await _cursoService.ObterTodos( c => c.Aulas);

            return await _cursoService.ObterTodos();
        }
    }
}
