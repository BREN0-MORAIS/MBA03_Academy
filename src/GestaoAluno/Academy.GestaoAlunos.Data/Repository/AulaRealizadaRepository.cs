using Academy.Core.Data.Repository;
using Academy.GestaoAlunos.Data.Context;
using Academy.GestaoAlunos.Domain.Entities;
using Academy.GestaoAlunos.Domain.Interface;

namespace Academy.GestaoAlunos.Data.Repository;

public class AulaRealizadaRepository : Repository<AulaRealizada>, IAulaRealizadaRepository
{
    public AulaRealizadaRepository(GestaoAlunosContext context) : base(context) { }   
}
