using Academy.Core.DomainObjects.Validations;
using Academy.Core.Entities;
using Academy.Core.Interfaces;
using Academy.GestaoAlunos.Domain.ObjectValue;

namespace Academy.GestaoAlunos.Domain.Entities;

public class ProgressoAluno : EntidadeBase, IAggregateRoot
{
    public string UserId { get; private set; }   
    public HistoricoAprendizado HistoricoAprendizado { get; private set; }

    public ProgressoAluno()
    {
        
    }
    public ProgressoAluno(string userId, HistoricoAprendizado historicoAprendizado)
    {
        UserId = userId;
        HistoricoAprendizado = historicoAprendizado;
        Validar();
    }

    public void Validar()
    {
        Validacoes.ValidarSeVazio(UserId, "UserId não pode ser vazio.");
        Validacoes.ValidarSeNulo(HistoricoAprendizado, "HistoricoAprendizado não ser nulo");
    }
}
