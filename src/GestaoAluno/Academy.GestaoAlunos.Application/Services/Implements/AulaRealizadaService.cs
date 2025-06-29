using Academy.Core.Exceptions;
using Academy.GestaoAlunos.Application.Dtos;
using Academy.GestaoAlunos.Application.Services.Interfaces;
using Academy.GestaoAlunos.Domain.Entities;
using Academy.GestaoAlunos.Domain.Enums;
using Academy.GestaoAlunos.Domain.Interface;
using AutoMapper;

namespace Academy.GestaoAlunos.Application.Services.Implements;

public class AulaRealizadaService : IAulaRealizadaService
{

    public IAulaConsultaExterna _aulaConsultaExterna { get; set; }
    public ICursoConsultaExterna _cursoConsultaExterna { get; set; }
    private readonly IMapper _mapper;
    public IProgressoAlunoCursoRepository _progressoAlunoCursoRepository { get; set; }
    public IAulaRealizadaRepository _aulaRealizadaRepository { get; set; }
    public IMatriculaRepository _matriculaRepository { get; set; }
    public AulaRealizadaService(IAulaConsultaExterna aulaConsultaExterna, ICursoConsultaExterna cursoConsultaExterna, IMapper mapper, IProgressoAlunoCursoRepository progressoAlunoCursoRepository, IAulaRealizadaRepository aulaRealizadaRepository, IMatriculaRepository matriculaRepository)
    {
        _aulaConsultaExterna = aulaConsultaExterna;
        _cursoConsultaExterna = cursoConsultaExterna;
        _mapper = mapper;
        _progressoAlunoCursoRepository = progressoAlunoCursoRepository;
        _aulaRealizadaRepository = aulaRealizadaRepository;
        _matriculaRepository = matriculaRepository;
    }
    public async Task<Guid> Criar(AulaRealizadaDto aulaRealizadaDto)
    {
        var matricula = await _matriculaRepository.ObterPorId(aulaRealizadaDto.MatriculaId);
        await Validar(aulaRealizadaDto, matricula);
        var aula = _mapper.Map<AulaRealizada>(aulaRealizadaDto);
        aula.DefinirCursoId(matricula.CursoId);
        await _aulaRealizadaRepository.Adicionar(aula);
        await RegistrarProgresso(matricula);
        return aula.Id;
    }

    public async Task RegistrarProgresso(Matricula matricula)
    {
        var cursoRespostaExterna = await _cursoConsultaExterna.ObterCursoDetalhadoAsync(matricula.CursoId);
        var aulasRealizadas = await _aulaRealizadaRepository.ObterListaEntidadePorFiltro(x => x.CursoId == matricula.CursoId && x.MatriculaId == matricula.Id);
        var progressoAlunoCurso = await _progressoAlunoCursoRepository.ObterEntidadePorFiltro(x => x.CursoId == matricula.CursoId);
        if (progressoAlunoCurso is not null)
        {
            await progressoAlunoCurso.RegistrarProgresso(cursoRespostaExterna.Aulas.Count(), aulasRealizadas.Count());
            _progressoAlunoCursoRepository.Atualizar(progressoAlunoCurso);
            return;
        }
        progressoAlunoCurso = new ProgressoAlunoCurso(matricula.CursoId, matricula.UserId, matricula.Id);
        await progressoAlunoCurso.RegistrarProgresso(cursoRespostaExterna.Aulas.Count(), aulasRealizadas.Count());
        await _progressoAlunoCursoRepository.Adicionar(progressoAlunoCurso);
    }

    public async Task Validar(AulaRealizadaDto aulaRealizadaDto, Matricula matriculaStatus)
    {
        var aulaRealizada = await _aulaRealizadaRepository.ObterEntidadePorFiltro(x => x.AulaId == aulaRealizadaDto.AulaId);
        if (aulaRealizada is not null) throw new DomainException("Aula ja foi realizada.");
        if (matriculaStatus is null) throw new DomainException("Matricula não informada.");
        if (!await _aulaConsultaExterna.AulaExisteAsync(aulaRealizadaDto.AulaId)) throw new DomainException("O Aula informado não existe.");
        if (matriculaStatus.Status != MatriculaStatus.Ativo) throw new DomainException($"A matricula esta como {matriculaStatus.Status.ToString().ToLower()}");
    }
}
