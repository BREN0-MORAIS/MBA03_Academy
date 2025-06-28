using Academy.GestaoConteudo.Application.Dtos;
using MediatR;

namespace Academy.GestaoConteudo.Application.CQRS.Queries.ObterCursoPorId;

public class ObterCursoPorIdQuery : IRequest<CursoDto>
{
    public Guid Id { get; set; }
}
