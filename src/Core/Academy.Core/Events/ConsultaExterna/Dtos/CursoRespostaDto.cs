
public class CursoRespostaDto
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int Status { get; set; }
    public decimal Valor { get; set; }
    public string Objetivo { get; set; }
    public string PreRequisitos { get; set; }
    public List<AulaRespostaDto> Aulas { get; set; }
}