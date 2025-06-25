using Academy.GestaoConteudo.Application.Validators;
using Academy.GestaoConteudo.Domain.Entities;
using Academy.GestaoConteudo.Domain.ObjectValue;
using AutoMapper;

namespace Academy.GestaoConteudo.Application.AutorMapper;

public class GestaoConteudoMap : Profile
{
    public GestaoConteudoMap()
    {
        CreateMap<CursoDto, Curso>().ConstructUsing(dto => new Curso(
              dto.Titulo,
              dto.Descricao,
              dto.Status,
              dto.Valor,
              new ConteudoProgramatico(dto.Objetivo, dto.PreRequisitos)
            ));


        CreateMap<Curso, CursoDto>()
            .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
            .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Valor))
            .ForMember(dest => dest.Objetivo, opt => opt.MapFrom(src => src.ConteudoProgramatico.Objetivo))
            .ForMember(dest => dest.PreRequisitos, opt => opt.MapFrom(src => src.ConteudoProgramatico.PreRequisitos));
    }
}
