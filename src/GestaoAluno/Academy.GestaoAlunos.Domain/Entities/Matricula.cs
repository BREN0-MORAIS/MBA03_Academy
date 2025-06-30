using Academy.Core.DomainObjects.Validations;
using Academy.Core.Entities;
using Academy.Core.Interfaces;
using Academy.GestaoAlunos.Domain.Enums;

namespace Academy.GestaoAlunos.Domain.Entities;

public class Matricula : EntidadeBase, IAggregateRoot
{
    public string UserId { get; private set; }
    //public Curso Curso { get; set; }
    public Guid CursoId { get; private set; }
    public DateTime DataConclusao { get; private set; }
    public MatriculaStatus Status { get; private set; }
    public ICollection<AulaRealizada> AulasRealizadas { get; private set; }
    public Certificado certificado { get; private set; }
    public Matricula(){}
    public Matricula(string userId, Guid cursoId)
    {
        UserId = userId;
        CursoId = cursoId;
        Status = MatriculaStatus.PendentePagamento;
        Validar();
    }
    public void ConcluirCurso()
    {
        Status = MatriculaStatus.Concluido;
        DataConclusao = DateTime.Now;
    }
    public void AtivarMatricula()
    {
        Status = MatriculaStatus.Ativo;
    }
    public void Validar()
    {
        Validacoes.ValidarSeVazio(UserId.ToString(), "UserId não pode ser vazio");
        Validacoes.ValidarSeVazio(CursoId.ToString(), "CursoId não pode ser vazio");
    }

}
