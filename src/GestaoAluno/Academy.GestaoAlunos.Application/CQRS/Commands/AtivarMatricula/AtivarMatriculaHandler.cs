using Academy.GestaoAlunos.Application.CQRS.Commands.FinalizarCurso;
using Academy.GestaoAlunos.Application.Services.Interfaces;
using Academy.GestaoAlunos.Domain.Interface;
using MediatR;

namespace Academy.GestaoAlunos.Application.CQRS.Commands.AtivarMatricula;

public class AtivarMatriculaHandler : IRequestHandler<AtivarMatriculaCommand, string>
{

    private IMatriculaService _matriculaService { get; set; }

    public AtivarMatriculaHandler(IMatriculaService matriculaService)
    {
        _matriculaService = matriculaService;
    }

    public async Task<string> Handle(AtivarMatriculaCommand request, CancellationToken cancellationToken)
    {
        return await _matriculaService.AtivarMatricula(request.MatriculaId, request.UserId);
    }
}
