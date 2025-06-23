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

    }
}
