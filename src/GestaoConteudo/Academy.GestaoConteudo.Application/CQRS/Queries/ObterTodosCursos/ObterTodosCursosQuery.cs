using Academy.GestaoConteudo.Application.Dtos;
using Academy.GestaoConteudo.Domain.Enums;
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
        public Guid Id { get; set; }
        public int Status { get; set; } 

    }
}
