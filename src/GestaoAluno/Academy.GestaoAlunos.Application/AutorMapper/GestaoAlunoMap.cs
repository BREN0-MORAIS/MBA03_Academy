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


        // CreateMap<CursoDto, Curso>().ConstructUsing(dto => new Curso(
        //  dto.Titulo,
        //  dto.Descricao,
        //  dto.Status,
        //  dto.Valor,
        //  new ConteudoProgramatico(dto.Objetivo, dto.PreRequisitos)
        //));
    }
}
