using Academy.GestaoConteudo.Domain.Enums;

namespace Academy.GestaoConteudo.Application.DTOs;

public class CursoDto
{
    public string Titulo { get;  set; }
    public string Descricao { get;  set; }
    public CursoStatus Status { get;  set; }
    public decimal Valor { get;  set; }
    public string Objetivo { get;  set; }
    public string PreRequisitos { get;  set; }
    public IEnumerable<AulaDto> Aulas { get; set; }
}
