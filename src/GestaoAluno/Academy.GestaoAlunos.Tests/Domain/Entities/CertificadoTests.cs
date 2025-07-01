using Academy.Core.Exceptions;
using Academy.GestaoAlunos.Domain.Entities;

namespace Academy.GestaoAlunos.Tests.Domain.Entities;

public class CertificadoTests
{
    [Fact]
    public void Certificado_Deve_Cadastrar_Certificado_Sem_Lacar_Excecao()
    {
        //Arrange
        var    userId = "92FC7EB4-3690-4538-97B3-026AD2BDB629";
        Guid   cursoId = Guid.NewGuid();
        Guid   matriculaId = Guid.NewGuid();
        string nomeDoAluno = "Paulo Vieira";
        string tituloDoCurso = "Full stack .NET";

        //Act
        var certificado = new Certificado(userId, cursoId, matriculaId, nomeDoAluno, tituloDoCurso);

        //Assert
        Assert.Equal(userId, certificado.UserId);
        Assert.Equal(cursoId, certificado.CursoId);
        Assert.Equal(matriculaId, certificado.MatriculaId);
        Assert.Equal(nomeDoAluno, certificado.NomeDoAluno);
        Assert.Equal(tituloDoCurso, certificado.TituloDoCurso);
    }

    [Fact]
    public void Certificado_Com_Dado_Invalidos_Deve_Lancar_Excecao()
    {
        //Arrange
        var userId = string.Empty;
        Guid cursoId = Guid.Empty;
        Guid matriculaId = Guid.Empty;
        string nomeDoAluno = string.Empty;
        string tituloDoCurso = string.Empty;

        //Act e Assert
        var exception = Assert.Throws<DomainException>(
            () => 
            new Certificado(userId, cursoId, matriculaId, nomeDoAluno, tituloDoCurso)
        );
    }

    [Fact]
    public void CursoId_Vazio_Deve_Lancar_Excecao()
    {
        //Arrange
        string userId = "92FC7EB4-3690-4538-97B3-026AD2BDB629";
        Guid cursoId = Guid.Empty ;
        Guid matriculaId = Guid.NewGuid();
        string nomeDoAluno = "Paulo";
        string tituloDoCurso = "Full Stack";

        //Act e Assert
        var exception = Assert.Throws<DomainException>(
            () =>
            new Certificado(userId, cursoId, matriculaId, nomeDoAluno, tituloDoCurso)
        );

        Assert.Equal("CursoId é obrigatório.", exception.Message);
    }
    [Fact]
    public void MatriculaId_Vazio_Deve_Lancar_Excecao()
    {
        //Arrange
        string userId = "92FC7EB4-3690-4538-97B3-026AD2BDB629";
        Guid cursoId =  Guid.NewGuid();
        Guid matriculaId = Guid.Empty;
        string nomeDoAluno = "Paulo";
        string tituloDoCurso = "Full Stack";

        //Act e Assert
        var exception = Assert.Throws<DomainException>(
            () =>
            new Certificado(userId, cursoId, matriculaId, nomeDoAluno, tituloDoCurso)
        );

        Assert.Equal("MatriculaId é obrigatório.", exception.Message);
    }

    [Fact]
    public void UserId_Nao_Registrado_Deve_Lancar_Excecao()
    {
        //Arrange
        string userId = null;
        Guid cursoId = Guid.NewGuid();
        Guid matriculaId = Guid.NewGuid();
        string nomeDoAluno = "Paulo";
        string tituloDoCurso = "Full Stack";

        //Act e Assert
        var exception = Assert.Throws<DomainException>(
            () =>
            new Certificado(userId, cursoId, matriculaId, nomeDoAluno, tituloDoCurso)
        );

        Assert.Equal("UserId é obrigatório.", exception.Message);
    }

    [Fact]
    public void Nome_Do_Aluno_Com_Tamanho_Invalido_Deve_Lancar_Excecao()
    {
        //Arrange
        var userId = "92FC7EB4-3690-4538-97B3-026AD2BDB629";
        Guid cursoId = Guid.NewGuid();
        Guid matriculaId = Guid.NewGuid();
        string nomeDoAluno = "Pa";
        string tituloDoCurso = "Full stack .NET";

        //Act e Assert
        var exception = Assert.Throws<DomainException>(
            () =>
            new Certificado(userId, cursoId, matriculaId, nomeDoAluno, tituloDoCurso)
        );

        Assert.Equal("O NomeDoAluno do aluno deve ter entre 3 e 100 caracteres.", exception.Message);
    }

    [Fact]
    public void Titulo_Do_Aluno_Com_Tamanho_Invalido_Deve_Lancar_Excecao()
    {
        //Arrange
        var userId = "92FC7EB4-3690-4538-97B3-026AD2BDB629";
        Guid cursoId = Guid.NewGuid();
        Guid matriculaId = Guid.NewGuid();
        string nomeDoAluno = "Paulo";
        string tituloDoCurso = "Fu";

        //Act e Assert
        var exception = Assert.Throws<DomainException>(
            () =>
            new Certificado(userId, cursoId, matriculaId, nomeDoAluno, tituloDoCurso)
        );

        Assert.Equal("O título do curso deve ter entre 3 e 150 caracteres.", exception.Message);
    }
}
