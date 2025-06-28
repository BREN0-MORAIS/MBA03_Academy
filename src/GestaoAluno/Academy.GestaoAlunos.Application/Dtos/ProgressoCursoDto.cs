namespace Academy.GestaoAlunos.Application.Dtos;

public class ProgressoCursoDto
{
    public Guid CursoId { get;  set; }
    public Guid UserId { get;  set; }
    public decimal Progresso { get;  set; }
}
