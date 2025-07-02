using Academy.Core.Exceptions;
using Academy.GestaoAlunos.Domain.Entities;
using System.Threading.Tasks;

namespace Academy.GestaoAlunos.Unidade.Tests.Domain.Entities;
public class ProgressoCursoTests
{
    [Fact]
    public void Progresso_Do_Aluno_Deve_Ser_Registrado_Com_Sucesso()
    {
        //Arrange
        Guid cursoId = Guid.NewGuid();
        string userId = Guid.NewGuid().ToString();
        Guid matriculaId = Guid.NewGuid();

        // Act
        var progressoAluno = new ProgressoAlunoCurso(cursoId, userId, matriculaId);

        // Assert
        Assert.Equal(cursoId, progressoAluno.CursoId);
        Assert.Equal(userId, progressoAluno.UserId);
        Assert.Equal(matriculaId, progressoAluno.MatriculaId);
    }

    [Fact]
    public void Progresso_Do_Aluno_Deve_Lancar_Execao_Se_Dados_Invalidos()
    {
        //Arrange
        Guid cursoId = Guid.Empty;
        string userId = string.Empty;
        Guid matriculaId = Guid.Empty;

        // Act & Assert
        Assert.Throws<DomainException>(() => new ProgressoAlunoCurso(cursoId, userId, matriculaId));
    }

    [Fact]
    public void Progresso_Do_Aluno_Deve_Lancar_Execao_Se_CursoId_Invalido()
    {
        //Arrange
        Guid cursoId = Guid.Empty;
        string userId = Guid.NewGuid().ToString();
        Guid matriculaId = Guid.NewGuid();

        // Act & Assert
        var exception = Assert.Throws<DomainException>(() => new ProgressoAlunoCurso(cursoId, userId, matriculaId));

        Assert.Equal("CursoId não pode ser vazio", exception.Message);
    }

    [Fact]
    public void Progresso_Do_Aluno_Deve_Lancar_Execao_Se_UserId_Invalido()
    {
        //Arrange
        Guid cursoId = Guid.NewGuid();
        string userId = string.Empty;
        Guid matriculaId = Guid.NewGuid();

        // Act & Assert
        var exception = Assert.Throws<DomainException>(() => new ProgressoAlunoCurso(cursoId, userId, matriculaId));

        Assert.Equal("UserId não pode ser vazio", exception.Message);
    }

    [Fact]
    public void Progresso_Do_Aluno_Deve_Lancar_Execao_Se_MatriculaId_Invalido()
    {
        //Arrange
        Guid cursoId = Guid.NewGuid();
        string userId = Guid.NewGuid().ToString();
        Guid matriculaId = Guid.Empty;

        // Act & Assert
        var exception = Assert.Throws<DomainException>(() => new ProgressoAlunoCurso(cursoId, userId, matriculaId));

        Assert.Equal("MatriculaId não pode ser vazio", exception.Message);
    }


    [Fact]
    public async Task Registrar_Progresso_Deve_Ser_Igual_50()
    {
        //Arrange
        Guid cursoId = Guid.NewGuid();
        string userId = Guid.NewGuid().ToString();
        Guid matriculaId = Guid.NewGuid();

        // Act
        var progressoAluno = new ProgressoAlunoCurso(cursoId, userId, matriculaId);

        await progressoAluno.RegistrarProgresso(10, 5);

        // Assert
        Assert.Equal(progressoAluno.Progresso, 50.00M);
    }


    [Fact]
    public async Task Registrar_Progresso_Deve_Ser_Igual_100()
    {
        //Arrange
        Guid cursoId = Guid.NewGuid();
        string userId = Guid.NewGuid().ToString();
        Guid matriculaId = Guid.NewGuid();

        // Act
        var progressoAluno = new ProgressoAlunoCurso(cursoId, userId, matriculaId);

        await progressoAluno.RegistrarProgresso(10, 10);

        // Assert
        Assert.Equal(progressoAluno.Progresso, 100.00M);
    }
    [Fact]
    public async Task Registrar_Progresso_Com_Dados_Negativo_Deve_Lancar_Execao()
    {
        //Arrange
        Guid cursoId = Guid.NewGuid();
        string userId = Guid.NewGuid().ToString();
        Guid matriculaId = Guid.NewGuid();

        // Act
        var progressoAluno = new ProgressoAlunoCurso(cursoId, userId, matriculaId);

        await Assert.ThrowsAsync<DomainException>(() =>
              progressoAluno.RegistrarProgresso(-10, -10));
    }

    [Fact]
    public async Task Registrar_Progresso_Com_Total_Negativo_Deve_Lancar_Execao()
    {
        //Arrange
        Guid cursoId = Guid.NewGuid();
        string userId = Guid.NewGuid().ToString();
        Guid matriculaId = Guid.NewGuid();

        // Act
        var progressoAluno = new ProgressoAlunoCurso(cursoId, userId, matriculaId);

        var exception = await Assert.ThrowsAsync<DomainException>(() =>
              progressoAluno.RegistrarProgresso(-10, 10));


        // Assert
        Assert.Equal("total não pode ser menor que 0", exception.Message);
    }

    [Fact]
    public async Task Registrar_Progresso_Com_Concluidas_Negativo_Deve_Lancar_Execao()
    {
        //Arrange
        Guid cursoId = Guid.NewGuid();
        string userId = Guid.NewGuid().ToString();
        Guid matriculaId = Guid.NewGuid();

        // Act
        var progressoAluno = new ProgressoAlunoCurso(cursoId, userId, matriculaId);

        var exception = await Assert.ThrowsAsync<DomainException>(() =>
              progressoAluno.RegistrarProgresso(10, -10));

        // Assert
        Assert.Equal("o campo concluidas não pode ser menor que 0", exception.Message);
    }

}
