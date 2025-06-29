using Academy.GestaoAlunos.Application.Dtos;
using MediatR;

namespace Academy.GestaoAlunos.Application.CQRS.Queries.ObterTodasMinhasMatriculas;

public class ObterTodasMinhasMatriculasQuery :  IRequest<IEnumerable<MinhasMatriculaDto>>
{
    public string UserId { get; set; }
    public ObterTodasMinhasMatriculasQuery(string userId)
    {
        UserId = userId;
    }
}
