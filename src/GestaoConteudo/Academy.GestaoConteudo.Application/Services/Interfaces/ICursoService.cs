using Academy.GestaoConteudo.Application.DTOs;
using Academy.GestaoConteudo.Domain.Entities;
using System.Linq.Expressions;

namespace Academy.GestaoConteudo.Application.Services.Interfaces;

public interface ICursoService
{
    Task<Guid> Criar(CursoDto cursoDto);
    Task<IEnumerable<CursoDto>> ObterTodos();
    Task<CursoDto> ObterPorId(Guid id, params Expression<Func<Curso, object>>[] includes);
    Task<IEnumerable<CursoDto>> ObterTodos(params Expression<Func<Curso, object>>[] includes);
    Task<Guid> Atualizar(Guid CursoId, CursoDto cursoDto);
}
