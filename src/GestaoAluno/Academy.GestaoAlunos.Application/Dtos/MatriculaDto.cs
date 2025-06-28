namespace Academy.GestaoAlunos.Application.Dtos;

public class MatriculaDto
{    public string UserId { get;  set; }
    //public Curso Curso { get; set; }
    public Guid CursoId { get;  set; }
    public DateTime DataConclusao { get;  set; }
    public int Status { get;  set; }
    //public ICollection<AulaRealizada> AulasRealizadas { get; private set; }
}


