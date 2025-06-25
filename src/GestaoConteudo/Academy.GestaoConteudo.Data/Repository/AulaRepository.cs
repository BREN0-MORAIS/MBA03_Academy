using Academy.Core.Data.Repository;
using Academy.GestaoConteudo.Data.Context;
using Academy.GestaoConteudo.Domain.Entities;
using Academy.GestaoConteudo.Domain.Interface;

namespace Academy.GestaoConteudo.Data.Repository
{
    public class AulaRepository : Repository<Aula>, IAulaRepository
    {
        public AulaRepository(GestaoConteudoContext context) : base(context) { }
    
    }
}
