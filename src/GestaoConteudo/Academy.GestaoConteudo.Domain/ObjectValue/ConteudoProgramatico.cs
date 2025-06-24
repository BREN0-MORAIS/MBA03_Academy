using Academy.Core.DomainObjects.Validations;

namespace Academy.GestaoConteudo.Domain.ObjectValue;

public class ConteudoProgramatico
{
    public string Objetivo { get; private set; }
    public string PreRequisitos { get; private set; }

    public ConteudoProgramatico(string objetivo, string preRequisitos)
    {
        Objetivo = objetivo;
        PreRequisitos = preRequisitos;
        Validar();
    }

    public void Validar()
    {
        Validacoes.ValidarSeVazio(Objetivo, "O campo Objetivo não pode ser vazio.");
        Validacoes.ValidarSeMenorQue(Objetivo.Count(), 10, "O campo Objetivo não pode ser menor que 10 caracteres.");
        Validacoes.ValidarMinimoMaximo(Objetivo.Count(), 10, 500, "O campo Objetivo tem que ter no minimo 10 caracteres e no maximo 500");


        Validacoes.ValidarSeVazio(PreRequisitos, "O campo PreRequisitos não pode ser vazio.");
        Validacoes.ValidarSeMenorQue(PreRequisitos.Count(), 10, "O campo PreRequisitos não pode ser menor que 10 caracteres.");
        Validacoes.ValidarMinimoMaximo(PreRequisitos.Count(), 10, 500, "O campo PreRequisitos tem que ter no minimo 10 caracteres e no maximo 500");

    }
}
