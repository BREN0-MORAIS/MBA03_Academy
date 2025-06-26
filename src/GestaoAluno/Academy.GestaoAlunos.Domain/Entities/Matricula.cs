using Academy.Core.Entities;

namespace Academy.GestaoAlunos.Domain.Entities;

public class Matricula : EntidadeBase
{
    public Guid CursoId { get; set; }
}
