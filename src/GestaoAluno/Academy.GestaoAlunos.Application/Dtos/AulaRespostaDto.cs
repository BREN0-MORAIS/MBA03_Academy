namespace Academy.GestaoAlunos.Application.Dtos;
public class AulaRespostaDto
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string VideoUrl { get; set; }
    public string Duracao { get; set; }
    public int Ordem { get; set; }
    public Guid CursoId { get; set; }
}