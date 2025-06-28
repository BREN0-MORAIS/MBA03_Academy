using Academy.Core.DomainObjects.Validations;
using Academy.Core.Entities;
using Academy.Core.Interfaces;

namespace Academy.GestaoAlunos.Domain.Entities;

public class AulaRealizada : EntidadeBase, IAggregateRoot
{
    public Guid CursoId { get; private set; }
    public Guid MatriculaId { get; private set; }
    public Guid AulaId { get; private set; }
    public Matricula Matricula { get; private set; }

    public AulaRealizada(Guid cursoId, Guid matriculaId, Guid aulaId)
    {
        CursoId = cursoId;
        MatriculaId = matriculaId;
        AulaId = aulaId;
        Validar();
    }

    public void Validar()
    {
        Validacoes.ValidarSeVazio(CursoId.ToString(), "O CursoId não pode ser vazio");
        Validacoes.ValidarSeVazio(MatriculaId.ToString(), "MatriculaId não pode ser vazio");
        Validacoes.ValidarSeVazio(AulaId.ToString(), "AulaId  não pode ser vazio");
    }

}
