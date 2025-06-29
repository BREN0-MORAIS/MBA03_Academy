using Academy.GestaoAlunos.Application.Dtos;
using System.Linq.Expressions;

namespace Academy.GestaoAlunos.Application.Services.Interfaces;

public interface IAulaRealizadaService
{
    Task<Guid> Criar(AulaRealizadaDto aulaRealizadaDto);
    //Task<IEnumerable<AulaRealizadaDto>> ObterTodos();
    //Task<AulaRealizadaDto> ObterPorId(Guid id, params Expression<Func<AulaRealizadaDto, object>>[] includes);
    //Task<Guid> Atualizar(Guid aulaRealizadaId, MatriculaDto aulaRealizadaDto);
}
