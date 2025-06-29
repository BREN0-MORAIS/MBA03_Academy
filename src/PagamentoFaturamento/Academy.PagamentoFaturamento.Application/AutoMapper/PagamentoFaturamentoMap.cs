using Academy.PagamentoFaturamento.Application.Dto;
using Academy.PagamentoFaturamento.Domain.ValueObjects;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.PagamentoFaturamento.Application.AutoMapper;

public class PagamentoFaturamentoMap : Profile
{
    public PagamentoFaturamentoMap()
    {
        CreateMap<PagamentoDto, DadosCartao>()
            .ConstructUsing(src => new DadosCartao(
                src.NomeTitular,
                src.NumeroCartaoCompleto,
                src.Expiracao,
                src.Cvv,
                src.Bandeira
            ));
    }
}
