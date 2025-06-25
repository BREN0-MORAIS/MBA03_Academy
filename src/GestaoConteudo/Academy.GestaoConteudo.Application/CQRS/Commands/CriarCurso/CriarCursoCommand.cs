using Academy.GestaoConteudo.Domain.Enums;
using MediatR;
namespace Academy.GestaoConteudo.Application.CQRS.Commands.CriarCurso;

public class CriarCursoCommand : IRequest<Guid>
{
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public CursoStatus Status { get; private set; }
    public decimal Valor { get; private set; }
    public string Objetivo { get; private set; }
    public string PreRequisitos { get; private set; }

    public CriarCursoCommand(string titulo, string descricao, CursoStatus status, decimal valor, string objetivo, string preRequisitos)
    {
        Titulo = titulo;
        Descricao = descricao;
        Status = status;
        Valor = valor;
        Objetivo = objetivo;
        PreRequisitos = preRequisitos;
    }
}
