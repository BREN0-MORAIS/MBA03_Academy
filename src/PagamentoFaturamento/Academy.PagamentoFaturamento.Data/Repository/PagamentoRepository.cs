using Academy.Core.Data.Repository;
using Academy.PagamentoFaturamento.Data.Context;
using Academy.PagamentoFaturamento.Domain.Entities;
using Academy.PagamentoFaturamento.Domain.Repository;

namespace Academy.PagamentoFaturamento.Data.Repository;

public class PagamentoRepository : Repository<Pagamento>, IPagamentoRepository
{
    public PagamentoRepository(PagamentoFaturamentoContext context) : base(context) { }

}
