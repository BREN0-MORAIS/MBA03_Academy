using Academy.GestaoAlunos.Application.Dtos;
using Academy.GestaoAlunos.Domain.Entities;
using AutoMapper;

namespace Academy.GestaoAlunos.Application.AutorMapper;

public class GestaoAlunoMap : Profile
{
    public GestaoAlunoMap()
    {

        CreateMap<MatriculaDto, Matricula>()
             .ConstructUsing(dto => new Matricula(dto.UserId, dto.CursoId))
             .ForMember(dest => dest.Status, opt => opt.Ignore())
             .ForMember(dest => dest.DataConclusao, opt => opt.Ignore())
             .ForMember(dest => dest.AulasRealizadas, opt => opt.Ignore());


        CreateMap<AulaRealizadaDto, AulaRealizada>()
          .ConstructUsing(dto => new AulaRealizada(dto.CursoId, dto.AulaId))
          .ForMember(dest => dest.DataCadastro, opt => opt.Ignore())
          .ForMember(dest => dest.CursoId, opt => opt.Ignore());

        CreateMap<Matricula, MinhasMatriculaDto>()
          .ForMember(dest => dest.MatriculaId, opt => opt.MapFrom(src => src.Id))
          .ForMember(dest => dest.CursoId, opt => opt.MapFrom(src => src.CursoId))
          .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.GetDisplayName()));

        // CreateMap<CursoDto, Curso>().ConstructUsing(dto => new Curso(
        //  dto.Titulo,
        //  dto.Descricao,
        //  dto.Status,
        //  dto.Valor,
        //  new ConteudoProgramatico(dto.Objetivo, dto.PreRequisitos)
        //));
    }
}
