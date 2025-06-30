using Academy.Core.Exceptions;
using Academy.GestaoAlunos.Application.Dtos;
using Academy.GestaoAlunos.Application.Services.Interfaces;
using Academy.GestaoAlunos.Domain.Entities;
using Academy.GestaoAlunos.Domain.Enums;
using Academy.GestaoAlunos.Domain.Interface;
using AutoMapper;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Academy.GestaoAlunos.Application.Services.Implements;

public class MatriculaService : IMatriculaService
{
    private readonly IMapper _mapper;
    private IMatriculaRepository _matriculaRepository { get; set; }
    private IProgressoAlunoCursoRepository _progressoAlunoCursoRepository { get; set; }
    private ICursoConsultaExterna _cursoConsultaExterna { get; set; }
    public MatriculaService(IMapper mapper, IMatriculaRepository matriculaRepository, IProgressoAlunoCursoRepository progressoAlunoCursoRepository, ICursoConsultaExterna cursoConsultaExterna)
    {
        _mapper = mapper;
        _matriculaRepository = matriculaRepository;
        _progressoAlunoCursoRepository = progressoAlunoCursoRepository;
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

    public async Task<string> AtivarMatricula(Guid matriculaId, string userid)
    {
        var matricula = await _matriculaRepository.ObterPorId(matriculaId);
        await ValidarAtivarMatricula(matricula, userid);
        matricula.AtivarMatricula();
        _matriculaRepository.Atualizar(matricula);


        return "Matricula Ativada com sucesso!";
    }



    public async Task<string> FinalizarCurso(Guid matriculaId, string userid)
    {
        var  matricula = await _matriculaRepository.ObterPorId(matriculaId);
        await  ValidarFinalizacaoCurso(matricula, userid);
        matricula.ConcluirCurso();
        _matriculaRepository.Atualizar(matricula);

        return string.Empty;
    }
    public async Task  ValidarAtivarMatricula(Matricula matricula, string userid)
    {
        if (!matricula.UserId.Equals(userid)) throw new DomainException("Usuário não cadastrado para esta Matricula.");
        if (matricula is null) throw new DomainException("Matricula não cadastrada");
    }
    public async Task  ValidarFinalizacaoCurso(Matricula matricula, string userid)
    {
        if (!matricula.UserId.Equals(userid)) throw new DomainException("Usuário não cadastrado para esta Matricula.");
        if (matricula is null) throw new DomainException("Matricula não cadastrada");
        if (!matricula.Status.Equals(MatriculaStatus.Ativo)) throw new DomainException("Matricula inativa ou pendente pagamento.");
        var verificarProgresso = await _progressoAlunoCursoRepository.ObterEntidadePorFiltro(x => x.MatriculaId ==  matricula.Id);
        if (verificarProgresso is  null) throw new DomainException("Aluno não tem progresso registrado");
        if (verificarProgresso.Progresso < 100) throw new DomainException("Aluno não finalizou todos as aulas");
    }

    public Task<Guid> Atualizar(Guid MatriculaId, MatriculaDto matriculaDto)
    {
        throw new NotImplementedException();
    }

    public Task<MatriculaDto> ObterPorId(Guid id, params Expression<Func<Matricula, object>>[] includes)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<MinhasMatriculaDto>> ObterTodasMinhasMatriculas(string userId)
    {
        var matriculas = await _matriculaRepository.ObterListaEntidadePorFiltro(x => x.UserId.Equals(userId));
        var matriculasDto = _mapper.Map<IEnumerable<MinhasMatriculaDto>>(matriculas);
        return matriculasDto;
    }

    public Task<IEnumerable<MatriculaDto>> ObterTodos()
    {
        throw new NotImplementedException();
    }
}
