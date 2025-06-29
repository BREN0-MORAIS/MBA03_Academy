using Academy.GestaoConteudo.Application.Dtos;
using MediatR;

namespace Academy.GestaoConteudo.Application.CQRS.Queries.ObterAulaAtivaPorId;

public class ObterAulaAtivaPorIdQuery :  IRequest<AulaDto>
{
    public Guid AulaId { get; set; }
}
