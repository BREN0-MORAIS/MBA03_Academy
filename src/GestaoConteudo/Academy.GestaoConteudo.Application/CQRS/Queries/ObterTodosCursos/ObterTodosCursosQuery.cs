using Academy.GestaoConteudo.Application.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.GestaoConteudo.Application.CQRS.Queries.ObterTodosCursos
{
    public class ObterTodosCursosQuery : IRequest<IEnumerable<CursoDto>>
    {
    }
}
