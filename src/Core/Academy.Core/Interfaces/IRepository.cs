using System.Linq.Expressions;

namespace Academy.Core.Interfaces;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
    Task<IEnumerable<T>> ObterTodos();
    Task<T?> ObterPorId(Guid id);
    Task<T?> ObterPorId(Guid id, params Expression<Func<T, object>>[] includes);
    Task<T> ObterEntidadePorFiltro(Expression<Func<T, bool>> expression);
    Task<IEnumerable<T>> ObterListaEntidadePorFiltro(Expression<Func<T, bool>> expression);
    Task<T> Adicionar(T aluno);
    void Atualizar(T aluno);

    IUnitOfWork UnitOfWork { get; }
}
