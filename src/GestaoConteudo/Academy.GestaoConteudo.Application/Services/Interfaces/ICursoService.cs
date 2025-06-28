using Academy.GestaoConteudo.Application.Dtos;
using Academy.GestaoConteudo.Domain.Entities;
using Academy.GestaoConteudo.Domain.Enums;
using System.Linq.Expressions;

namespace Academy.GestaoConteudo.Application.Services.Interfaces;

public interface ICursoService
{
    Task<Guid> Criar(CursoDto cursoDto);
    Task<IEnumerable<CursoDto>> ObterTodos();
    Task<CursoDto> ObterPorId(Guid id, params Expression<Func<Curso, object>>[] includes);
    Task<IEnumerable<CursoDto>> ObterTodos(CursoStatus status = CursoStatus.Todos, params Expression<Func<Curso, object>>[] includes);
    Task<Guid> Atualizar(Guid CursoId, CursoDto cursoDto);
}
