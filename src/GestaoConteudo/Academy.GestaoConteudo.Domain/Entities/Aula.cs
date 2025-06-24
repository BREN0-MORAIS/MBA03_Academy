using Academy.Core.DomainObjects.Validations;
using Academy.Core.Entities;
namespace Academy.GestaoConteudo.Domain.Entities;

public class Aula: EntidadeBase
{

    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public string VideoUrl { get; private set; }
    public TimeSpan Duracao { get; private set; }
    public int Ordem { get; private set; }
    public Curso Curso { get; private set; }
    public Guid CursoId { get; private set; }

    public Aula() {}

    public Aula(string titulo, string descricao, string videoUrl, TimeSpan duracao, int ordem,  Guid cursoId)
    {
        Titulo = titulo;
        Descricao = descricao;
        VideoUrl = videoUrl;
        Duracao = duracao;
        Ordem = ordem;
        CursoId = cursoId;

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

        Validacoes.ValidarSeVazio(VideoUrl, "O campo VideoUrl não pode ser vazio.");
        Validacoes.ValidarSeMenorQue(VideoUrl.Count(), 10, "O campo VideoUrl não pode ser menor que 10 caracteres.");

        Validacoes.ValidarSeMenorQue(VideoUrl.Count(), 0, "O campo VideoUrl não pode ser menor que 10 caracteres.");

        Validacoes.ValidarSeIgual(CursoId, Guid.Empty, "O campo CursoId não pode vazio.");
    }

}
