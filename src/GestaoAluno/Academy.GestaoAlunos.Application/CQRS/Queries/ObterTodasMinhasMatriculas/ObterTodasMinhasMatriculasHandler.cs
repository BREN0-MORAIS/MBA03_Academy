using Academy.GestaoAlunos.Application.Dtos;
using Academy.GestaoAlunos.Application.Services.Interfaces;
using MediatR;

namespace Academy.GestaoAlunos.Application.CQRS.Queries.ObterTodasMinhasMatriculas;

public class ObterTodasMinhasMatriculasHandler : IRequestHandler<ObterTodasMinhasMatriculasQuery, IEnumerable<MinhasMatriculaDto>>
{
    private IMatriculaService _matriculaService;

    public ObterTodasMinhasMatriculasHandler(IMatriculaService matriculaService)
    {
        _matriculaService = matriculaService;
    }

    public async Task<IEnumerable<MinhasMatriculaDto>> Handle(ObterTodasMinhasMatriculasQuery request, CancellationToken cancellationToken)
    {

        var matriculas = await _matriculaService.ObterTodasMinhasMatriculas(request.UserId);

        return matriculas;
    }
}
