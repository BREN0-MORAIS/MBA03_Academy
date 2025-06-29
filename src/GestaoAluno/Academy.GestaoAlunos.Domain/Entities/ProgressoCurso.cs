using Academy.Core.DomainObjects.Validations;
using Academy.Core.Entities;
using Academy.Core.Interfaces;

namespace Academy.GestaoAlunos.Domain.Entities;
public class ProgressoAlunoCurso : EntidadeBase, IAggregateRoot
{
    public Guid CursoId { get; private set; }
    public Guid MatriculaId { get; private set; }
    public string UserId { get; private set; }
    public decimal Progresso { get;  private  set; }

    public Matricula Matricula { get; private set; }
    public ProgressoAlunoCurso(){}
    public ProgressoAlunoCurso(Guid cursoId, string userId, Guid matriculaId)
    {
        CursoId = cursoId;
        UserId = userId;
        MatriculaId = matriculaId;
        Validar();
    }
    public void Validar()
    {
        Validacoes.ValidarSeVazio(CursoId.ToString(), "UserId não pode ser vazio");
        Validacoes.ValidarSeVazio(UserId.ToString(), "CursoId não pode ser vazio");
        Validacoes.ValidarSeVazio(MatriculaId.ToString(), "CursoId não pode ser vazio");
    }
    public async Task RegistrarProgresso( int total, int concluidas)
    {
        if (total == 0)
        {
            Progresso = 0;
            return;
        }

        Progresso = Math.Round((decimal)concluidas / total * 100, 2);
    }
}
