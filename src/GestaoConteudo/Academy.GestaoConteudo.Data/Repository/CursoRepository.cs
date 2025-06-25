using Academy.Core.Data.Repository;
using Academy.GestaoConteudo.Data.Context;
using Academy.GestaoConteudo.Domain.Entities;
using Academy.GestaoConteudo.Domain.Interface;

namespace Academy.GestaoConteudo.Data.Repositories;

public class CursoRepository : Repository<Curso>, ICursoRepository
{
    public CursoRepository(GestaoConteudoContext context) : base(context) { }
}
