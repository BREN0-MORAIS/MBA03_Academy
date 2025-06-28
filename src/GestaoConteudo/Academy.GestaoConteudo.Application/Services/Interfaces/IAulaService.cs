using Academy.GestaoConteudo.Application.Dtos;

namespace Academy.GestaoConteudo.Application.Services.Interfaces
{
    public interface IAulaService
    {
        Task<Guid> Criar(AulaDto cursoDto);
        Task<IEnumerable<AulaDto>> ObterTodos();
        Task<Guid> Atualizar(Guid AulaId, AulaDto aulaDto);
    }
}
