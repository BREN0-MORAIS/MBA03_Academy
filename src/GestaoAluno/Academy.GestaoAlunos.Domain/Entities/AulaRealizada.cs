using Academy.Core.Entities;

namespace Academy.GestaoAlunos.Domain.Entities;

public class AulaRealizada : EntidadeBase
{
    public Guid CursoId { get; private set; }
    public Guid MatriculaId { get; private set; }
    public Guid AulaId { get; private set; }

    public Matricula Matricula { get; set; }
}
