using Academy.GestaoConteudo.Application.Dtos;
using MediatR;

namespace Academy.GestaoConteudo.Application.CQRS.Queries.ObterAulasPorCursoId;

public class ObterAulasPorCursoIdQuery : IRequest<CursoDto>
{
    public Guid CursoId { get; set; }
}
