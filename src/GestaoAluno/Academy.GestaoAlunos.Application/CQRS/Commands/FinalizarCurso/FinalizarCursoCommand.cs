using MediatR;

namespace Academy.GestaoAlunos.Application.CQRS.Commands.FinalizarCurso;

public class FinalizarCursoCommand : IRequest<string>
{
    
    public Guid MatriculaId { get; set; }
    public string UserId { get; set; }
    public string NomeAluno { get; set; }

    public FinalizarCursoCommand(Guid matriculaId, string userId, string nomeAluno)
    {
        MatriculaId = matriculaId;
        UserId = userId;
        NomeAluno = nomeAluno;
    }

}
