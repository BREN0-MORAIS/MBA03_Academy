using Academy.Core.Exceptions;
using Academy.GestaoAlunos.Domain.Entities;

namespace Academy.GestaoAlunos.Tests.Domain.Entities;

public class AulaRealizadaTests
{
    [Fact]
    public void MatriculaId_E_AulaId_Deve_Ser_Cadastrada_Sem_Excecao()
    {
        //Arrange
        var matriculaId = Guid.NewGuid();
        var aulaId = Guid.NewGuid();

        //act
        var aulaRealizada = new AulaRealizada(matriculaId, aulaId);

        //Assert
        Assert.Equal(matriculaId, aulaRealizada.MatriculaId);
        Assert.Equal(aulaId, aulaRealizada.AulaId);
    }

    [Fact]
    public void AulaId_E_MatriculaId_Deve_Lancar_Excecao()
    {
        // Arrange
        var matriculaId = Guid.Empty;
        var aulaId = Guid.Empty;

        // Act & Assert
        var exception = Assert.Throws<DomainException>(() => new AulaRealizada(matriculaId, aulaId));

        Assert.Contains("não pode ser vazio", exception.Message);
    }
}
