namespace Academy.GestaoAlunos.Application.Dtos;

public class AulaRealizadaDto
{
    public Guid CursoId { get;  set; }
    public Guid MatriculaId { get;  set; }
    public Guid AulaId { get;  set; }
    public MatriculaDto Matricula { get;  set; }
}
