using Academy.Core.Exceptions;
using Academy.GestaoAlunos.Application.Dtos;
using Academy.GestaoAlunos.Application.Services.Interfaces;
using Academy.GestaoAlunos.Domain.Entities;
using Academy.GestaoAlunos.Domain.Interface;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Academy.GestaoAlunos.Application.Services.Implements;

public class MatriculaService : IMatriculaService
{
    private readonly IMapper _mapper;
    private  IMatriculaRepository _matriculaRepository { get; set; }


    private ICursoConsultaExterna _cursoConsultaExterna { get; set; }

    public MatriculaService(IMapper mapper, IMatriculaRepository matriculaRepository, ICursoConsultaExterna cursoConsultaExterna)
    {
        _mapper = mapper;
        _matriculaRepository = matriculaRepository;
        _cursoConsultaExterna = cursoConsultaExterna;
    }

    public async Task<Guid> Criar(MatriculaDto MatriculaDto)
    {
       await Validar(MatriculaDto);

       var matricula = _mapper.Map<Matricula>(MatriculaDto);

       await _matriculaRepository.Adicionar(matricula);

        return matricula.Id;
    }

    public async Task Validar(MatriculaDto MatriculaDto)
    {
        if (!await _cursoConsultaExterna.CursoExisteAsync(MatriculaDto.CursoId)) throw new DomainException("O curso informado não existe.");
        
        var UsuarioMatriculadoNoCurso = await _matriculaRepository.ObterEntidadePorFiltro(x => x.CursoId.Equals(MatriculaDto.CursoId) && x.UserId.Equals(MatriculaDto.UserId));
        if (UsuarioMatriculadoNoCurso is not null) throw new DomainException("O Usuário ja esta Matriculado neste Curso");

    }


    public Task<Guid> Atualizar(Guid MatriculaId, MatriculaDto matriculaDto)
    {
        throw new NotImplementedException();
    }

    public Task<MatriculaDto> ObterPorId(Guid id, params Expression<Func<Matricula, object>>[] includes)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MatriculaDto>> ObterTodos()
    {
        throw new NotImplementedException();
    }
}
