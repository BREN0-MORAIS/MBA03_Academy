using Academy.Core.Data.Repository;
using Academy.GestaoAlunos.Data.Context;
using Academy.GestaoAlunos.Domain.Entities;
using Academy.GestaoAlunos.Domain.Interface;

namespace Academy.GestaoAlunos.Data.Repository;

public class ProgressoAlunoCursosRepository : Repository<ProgressoAlunoCurso>, IProgressoAlunoCursoRepository
{
    public ProgressoAlunoCursosRepository(GestaoAlunosContext context) : base(context) { }   
}
