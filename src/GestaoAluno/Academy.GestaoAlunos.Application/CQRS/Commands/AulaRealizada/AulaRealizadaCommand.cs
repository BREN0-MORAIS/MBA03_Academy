using MediatR;

namespace Academy.GestaoAlunos.Application.CQRS.Commands.AulaRealizada;

public class AulaRealizadaCommand : IRequest<Guid>
{
  
    public Guid MatriculaId { get; set; }
    public Guid AulaId { get; set; }
    public AulaRealizadaCommand(Guid matriculaId, Guid aulaId)
    {
        MatriculaId = matriculaId;
        AulaId = aulaId;
    }
}
