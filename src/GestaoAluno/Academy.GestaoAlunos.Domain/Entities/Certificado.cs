using Academy.Core.DomainObjects.Validations;
using Academy.Core.Entities;
using Academy.Core.Interfaces;
namespace Academy.GestaoAlunos.Domain.Entities;

public class Certificado : EntidadeBase, IAggregateRoot
{

    public string UserId { get; private set; }
    public Guid CursoId { get;  private set; }
    public Guid MatriculaId { get;  private set; }
    public string NomeDoAluno { get; private set; }
    public string TituloDoCurso { get; private set; }
    public DateTime DataEmissao { get; private set; }
    public string CodigoVerificacao { get; private set; }

    public Certificado()
    {
        
    }
    public Certificado(string userId, Guid cursoId, Guid matriculaId, string nomeDoAluno, string tituloDoCurso)
    {
        UserId = userId;
        CursoId = cursoId;
        MatriculaId = matriculaId;
        NomeDoAluno = nomeDoAluno;
        TituloDoCurso = tituloDoCurso;
        DataEmissao = DateTime.Now;
        CodigoVerificacao = $"{Guid.NewGuid().ToString()}";

        Validar();
    }

    private void Validar()
    {
        Validacoes.ValidarSeNulo(UserId, "O ID do UserId é obrigatório.");
        Validacoes.ValidarSeNulo(CursoId, "O ID do CursoId é obrigatório.");
        Validacoes.ValidarSeNulo(MatriculaId, "O ID do MatriculaId é obrigatório.");
        Validacoes.ValidarSeVazio(NomeDoAluno, "O nome do NomeDoAluno é obrigatório.");
        Validacoes.ValidarTamanho(NomeDoAluno, 3, 100, "O NomeDoAluno do aluno deve ter entre 3 e 100 caracteres.");

        Validacoes.ValidarSeVazio(TituloDoCurso, "O título do TituloDoCurso é obrigatório.");
        Validacoes.ValidarTamanho(TituloDoCurso, 3, 150, "O título do curso deve ter entre 3 e 150 caracteres.");
    }

}
