using Academy.GestaoAlunos.Application.Dtos;
using Academy.GestaoAlunos.Domain.Entities;
using System.Linq.Expressions;

namespace Academy.GestaoAlunos.Application.Services.Interfaces;

public interface IMatriculaService
{
    Task<Guid> Criar(MatriculaDto MatriculaDto);
    Task<IEnumerable<MatriculaDto>> ObterTodos();
    Task<IEnumerable<MinhasMatriculaDto>> ObterTodasMinhasMatriculas(string userId);
    Task<MatriculaDto> ObterPorId(Guid id, params Expression<Func<Matricula, object>>[] includes);
    //Task<IEnumerable<MatriculaDto>> ObterTodos(CursoStatus status = CursoStatus.Todos, params Expression<Func<Curso, object>>[] includes);
    Task<Guid> Atualizar(Guid matriculaId, MatriculaDto matriculaDto);
    Task<string> FinalizarCurso(Guid matriculaId, string userid);
}
