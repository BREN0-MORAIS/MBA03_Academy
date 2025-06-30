using Academy.GestaoConteudo.Application.Dtos;
using Academy.GestaoConteudo.Domain.Entities;
using Academy.GestaoConteudo.Domain.ObjectValue;
using AutoMapper;

namespace Academy.GestaoConteudo.Application.AutorMapper;

public class GestaoConteudoMap : Profile
{
    public GestaoConteudoMap()
    {
        CreateMap<CursoDto, Curso>()
             .ConstructUsing(dto => new Curso(
                 dto.Titulo,
                 dto.Descricao,
                 dto.Status,
                 dto.Valor,
                 new ConteudoProgramatico(dto.Objetivo, dto.PreRequisitos)
             ))
             .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Aula, AulaDto>();

        CreateMap<Curso, CursoDto>()
            .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
            .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Valor))
            .ForMember(dest => dest.Objetivo, opt => opt.MapFrom(src => src.ConteudoProgramatico.Objetivo))
            .ForMember(dest => dest.PreRequisitos, opt => opt.MapFrom(src => src.ConteudoProgramatico.PreRequisitos))
            .ForMember(dest => dest.Aulas, opt => opt.MapFrom(src => src.Aulas))
            ;

        CreateMap<Curso, CriarCursoDto>()
               .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
               .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
               .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Valor))
               .ForMember(dest => dest.Objetivo, opt => opt.MapFrom(src => src.ConteudoProgramatico.Objetivo))
               .ForMember(dest => dest.PreRequisitos, opt => opt.MapFrom(src => src.ConteudoProgramatico.PreRequisitos)).ReverseMap()
               ;


        CreateMap<AulaDto, Aula>().ConstructUsing(dto => new Aula(
            dto.Titulo,
            dto.Descricao,
            dto.VideoUrl,
            dto.Duracao,
            dto.Ordem,
            dto.CursoId
            )).ReverseMap();

    }
}
