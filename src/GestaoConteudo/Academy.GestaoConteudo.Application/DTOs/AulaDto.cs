using Academy.GestaoConteudo.Domain.Entities;

namespace Academy.GestaoConteudo.Application.DTOs;

public class AulaDto
{
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public string VideoUrl { get; private set; }
    public TimeSpan Duracao { get; private set; }
    public int Ordem { get; private set; }
    public Guid CursoId { get; private set; }
}
