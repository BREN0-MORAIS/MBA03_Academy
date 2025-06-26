using Academy.Core.DomainObjects.Validations;
using Academy.GestaoConteudo.Domain.Enums;
using Academy.GestaoConteudo.Domain.ObjectValue;
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
        Validar();
    }

    public void Validar()
    {
        Validacoes.ValidarSeVazio(Titulo, "O campo titulo não pode ser vazio.");
        Validacoes.ValidarSeMenorQue(Titulo.Count(), 5, "O campo titulo não pode ser menor que 5 caracteres.");
        Validacoes.ValidarMinimoMaximo(Titulo.Count(), 5, 50, "O campo titulo tem que ter no minimo 5 caracteres e no maximo 50");

        Validacoes.ValidarSeVazio(Descricao, "O campo titulo não pode ser vazio.");
        Validacoes.ValidarSeMenorQue(Descricao.Count(), 10, "O campo titulo não pode ser menor que 10 caracteres.");
        Validacoes.ValidarMinimoMaximo(Descricao.Count(), 10, 500, "O campo tem que ter no minimo 10 caracteres e no maximo 500");

        Validacoes.ValidarSeNulo(Status, "O campo status não pode ser nulo.");

        Validacoes.ValidarSeMenorQue(Valor, 5, "O Valor do curso não pode ser menor que 5");

        Validacoes.ValidarSeVazio(Objetivo, "O campo Objetivo não pode ser vazio.");
        Validacoes.ValidarSeMenorQue(Objetivo.Count(), 10, "O campo Objetivo não pode ser menor que 10 caracteres.");
        Validacoes.ValidarMinimoMaximo(Objetivo.Count(), 10, 500, "O campo Objetivo tem que ter no minimo 10 caracteres e no maximo 500");


        Validacoes.ValidarSeVazio(PreRequisitos, "O campo PreRequisitos não pode ser vazio.");
        Validacoes.ValidarSeMenorQue(PreRequisitos.Count(), 10, "O campo PreRequisitos não pode ser menor que 10 caracteres.");
        Validacoes.ValidarMinimoMaximo(PreRequisitos.Count(), 10, 500, "O campo PreRequisitos tem que ter no minimo 10 caracteres e no maximo 500");

    }
}
