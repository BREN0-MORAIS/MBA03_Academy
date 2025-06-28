namespace Academy.GestaoAlunos.Application.Dtos;

public class ProgressoAlunoDto
{
    public Guid UserId { get;  set; }
    public int TotalCursosConcluidos { get;  set; }
    public int TotalHoras { get;  set; }
}
