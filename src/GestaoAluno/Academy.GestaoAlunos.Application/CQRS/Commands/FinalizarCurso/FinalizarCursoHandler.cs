using Academy.GestaoAlunos.Application.Services.Interfaces;
using MediatR;

namespace Academy.GestaoAlunos.Application.CQRS.Commands.FinalizarCurso;

public class FinalizarCursoHandler : IRequestHandler<FinalizarCursoCommand, string>
{
    public IMatriculaService _matriculaService { get; set; }

    public FinalizarCursoHandler(IMatriculaService matriculaService)
    {
        _matriculaService = matriculaService;
    }
    public async Task<string> Handle(FinalizarCursoCommand request, CancellationToken cancellationToken)
    {
        return await _matriculaService.FinalizarCurso(new Dtos.FinalizarCursoDto
        {
            MatriculaId = request.MatriculaId,
            UserId = request.UserId,
            NomeAluno = request.NomeAluno
        }
        );
    }
}
