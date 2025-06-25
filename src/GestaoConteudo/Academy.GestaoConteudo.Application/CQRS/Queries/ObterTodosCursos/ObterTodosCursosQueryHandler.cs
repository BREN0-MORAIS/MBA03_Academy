using Academy.GestaoConteudo.Application.DTOs;
using Academy.GestaoConteudo.Application.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return await _cursoService.ObterTodos();
        }
    }
}
