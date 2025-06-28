using Academy.Core.Data.Repository;
using Academy.GestaoAlunos.Data.Context;
using Academy.GestaoAlunos.Domain.Entities;
using Academy.GestaoAlunos.Domain.Interface;

namespace Academy.GestaoAlunos.Data.Repository;

public class MatriculaRepository : Repository<Matricula>, IMatriculaRepository
{
    public MatriculaRepository(GestaoAlunosContext context) : base(context) { }
}
