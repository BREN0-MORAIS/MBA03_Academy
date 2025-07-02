using Academy.Core.Exceptions;
using Academy.GestaoAlunos.Domain.Entities;
using Academy.GestaoAlunos.Domain.Enums;

namespace Academy.GestaoAlunos.Tests.Domain.Entities;

public class MatriculaTests
{
    [Fact]
    public void UserId_E_CursoId_Deve_Ser_Cadastrada_Sem_Excecao()
    {
        //Arrange
        var userId = Guid.NewGuid().ToString();
        var cursoId = Guid.NewGuid();

        //act
        var matricula = new Matricula(userId, cursoId);

        //Assert
        Assert.Equal(userId, matricula.UserId);
        Assert.Equal(cursoId, matricula.CursoId);
        Assert.Equal(matricula.Status, MatriculaStatus.PendentePagamento);
    }

   

    [Fact]
    public void UserId_E_CursoId_Com_Dados_Invalidos_Devem_Lancar_Excecao()
    {
        //Arrange
        var userId = string.Empty;
        var cursoId = Guid.Empty;

        //Act & Assert
        Assert.Throws<DomainException>(() => new Matricula(userId, cursoId));
    }


    [Fact]
    public void UserId_Invalido_Lanca_Excecao()
    {
        //Arrange
        var userId = "";
        var cursoId = Guid.NewGuid();

       var exception =  Assert.Throws<DomainException>(() => new Matricula(userId, cursoId));

        Assert.Equal("UserId não pode ser vazio", exception.Message);

    }

    [Fact]
    public void CursoId_Invalido_Lanca_Excecao()
    {
        //Arrange
        var userId = Guid.NewGuid().ToString();
        var cursoId = Guid.Empty;

        var exception = Assert.Throws<DomainException>(() => new Matricula(userId, cursoId));

        Assert.Equal("CursoId não pode ser vazio", exception.Message);
    }


    [Fact]
    public void Finalizand_Curso_Status_Matricula_Para_Concluido_Data_Conclusao_Para_Data_Atual()
    {
        //Arrange
        var userId = Guid.NewGuid().ToString();
        var cursoId = Guid.NewGuid();

        //Act
        var matricula = new Matricula(userId, cursoId);

        //Assert
        Assert.Equal(userId, matricula.UserId);
        Assert.Equal(cursoId, matricula.CursoId);
        Assert.Equal(matricula.Status, MatriculaStatus.PendentePagamento);

        matricula.ConcluirCurso();

        Assert.Equal(matricula.Status, MatriculaStatus.Concluido);
        Assert.Equal(DateTime.Now.Date, matricula.DataConclusao.Date);
    }

}
