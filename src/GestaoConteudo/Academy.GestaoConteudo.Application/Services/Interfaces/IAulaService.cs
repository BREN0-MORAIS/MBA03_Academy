using Academy.GestaoConteudo.Application.Dtos;
using Academy.GestaoConteudo.Domain.Entities;
using System.Linq.Expressions;

namespace Academy.GestaoConteudo.Application.Services.Interfaces
{
    public interface IAulaService
    {
        Task<Guid> Criar(AulaDto cursoDto);
        Task<IEnumerable<AulaDto>> ObterTodos();
        Task<AulaDto> ObterPorId(Guid id);
        Task<Guid> Atualizar(Guid AulaId, AulaDto aulaDto);
    }
}
