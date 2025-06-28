using Academy.GestaoAlunos.Application.Dtos;
using Academy.GestaoAlunos.Application.Services.Interfaces;
using MediatR;

namespace Academy.GestaoAlunos.Application.CQRS.Commands.CriarMatricula;

public class CriarMatriculaHandler : IRequestHandler<CriarMatriculaCommand, Guid>
{
    public IMatriculaService _matriculaService { get; set; }
    public CriarMatriculaHandler(IMatriculaService matriculaService)
    {
        _matriculaService = matriculaService;
    }

    public async Task<Guid> Handle(CriarMatriculaCommand request, CancellationToken cancellationToken)
    {
        var matriculaDto = Mapear(request);

       return await _matriculaService.Criar(matriculaDto);
    }

    public MatriculaDto Mapear(CriarMatriculaCommand request)
    {
        return new MatriculaDto { CursoId = request.CursoId , UserId = request.UserId};
    }
}
