using MediatR;

namespace Academy.GestaoAlunos.Application.CQRS.Commands.FinalizarCurso;

public class FinalizarCursoCommand : IRequest<string>
{
    
    public Guid MatriculaId { get; set; }
    public string UserId { get; set; }

    public FinalizarCursoCommand(Guid matriculaId, string userId)
    {
        MatriculaId = matriculaId;
        UserId = userId;
    }

}
