using Academy.GestaoConteudo.Domain.Enums;
using MediatR;

namespace Academy.GestaoConteudo.Application.CQRS.Commands.AtualizarCurso;

public class AtualizarCursoCommand : IRequest<Guid> 
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public CursoStatus Status { get; set; }
    public decimal Valor { get; set; }
    public string Objetivo { get; set; }
    public string PreRequisitos { get; set; }

    public AtualizarCursoCommand(Guid id, string titulo, string descricao, CursoStatus status, decimal valor, string objetivo, string preRequisitos)
    {
        Id = id;
        Titulo = titulo;
        Descricao = descricao;
        Status = status;
        Valor = valor;
        Objetivo = objetivo;
        PreRequisitos = preRequisitos;
    }
}
