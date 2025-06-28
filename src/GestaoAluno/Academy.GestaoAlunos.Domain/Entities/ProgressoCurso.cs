using Academy.Core.DomainObjects.Validations;
using Academy.Core.Entities;
using Academy.Core.Interfaces;

namespace Academy.GestaoAlunos.Domain.Entities;
public class ProgressoAlunoCurso : EntidadeBase, IAggregateRoot
{
    public Guid CursoId { get; private set; }
    public string UserId { get; private set; }
    public decimal Progresso { get;  private  set; }

    public ProgressoAlunoCurso(Guid cursoId, string userId)
    {
        CursoId = cursoId;
        UserId = userId;
        Validar();
    }
    public void Validar()
    {
        Validacoes.ValidarSeVazio(CursoId.ToString(), "UserId não pode ser vazio");
        Validacoes.ValidarSeVazio(UserId.ToString(), "CursoId não pode ser vazio");
    }
    public void RegistrarProgresso(int concluidas, int total)
    {
        if (total == 0)
        {
            Progresso = 0;
            return;
        }

        Progresso = Math.Round((decimal)concluidas / total * 100, 2);
    }
}
