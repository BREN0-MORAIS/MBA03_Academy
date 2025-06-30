using MediatR;

namespace Academy.GestaoAlunos.Application.CQRS.Commands.AtivarMatricula;

public class AtivarMatriculaCommand : IRequest<string>
{
    public Guid MatriculaId { get; private set; }
    public string UserId { get; private set; }

    public AtivarMatriculaCommand(Guid matriculaId, string userId)
    {
        MatriculaId = matriculaId;
        UserId = userId;
    }
}
