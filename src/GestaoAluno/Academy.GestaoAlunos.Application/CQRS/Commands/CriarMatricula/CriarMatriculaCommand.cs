using MediatR;
namespace Academy.GestaoAlunos.Application.CQRS.Commands.CriarMatricula;

public class CriarMatriculaCommand : IRequest<Guid>
{
    public string UserId { get; set; }
    public Guid CursoId { get; set; }

    public CriarMatriculaCommand(string userId, Guid cursoId)
    {
        UserId = userId;
        CursoId = cursoId;
    }
}
