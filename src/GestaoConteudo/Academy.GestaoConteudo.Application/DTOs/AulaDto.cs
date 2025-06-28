using Academy.GestaoConteudo.Domain.Entities;

namespace Academy.GestaoConteudo.Application.Dtos;

public class AulaDto
{

    public Guid Id { get; set; }
    public string Titulo { get;  set; }
    public string Descricao { get;  set; }
    public string VideoUrl { get;  set; }
    public TimeSpan Duracao { get;  set; }
    public int Ordem { get;  set; }
    public Guid CursoId { get;  set; }
}

