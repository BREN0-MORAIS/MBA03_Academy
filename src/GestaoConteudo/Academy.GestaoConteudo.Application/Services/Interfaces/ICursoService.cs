using Academy.GestaoConteudo.Application.CQRS.Commands;
using Academy.GestaoConteudo.Application.Validators;
using System.Threading.Tasks;

namespace Academy.GestaoConteudo.Application.Services.Interfaces;

public interface ICursoService
{
    Task<Guid> Criar(CursoDto cursoDto);
    Task<IEnumerable<CursoDto>> ObterTodos();
    Task<Guid> Atualizar(Guid CursoId, CursoDto cursoDto);
}
