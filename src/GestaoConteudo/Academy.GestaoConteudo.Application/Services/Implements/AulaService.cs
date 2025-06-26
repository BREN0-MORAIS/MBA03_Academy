using Academy.GestaoConteudo.Application.DTOs;
using Academy.GestaoConteudo.Application.Services.Interfaces;
using Academy.GestaoConteudo.Domain.Entities;
using Academy.GestaoConteudo.Domain.Interface;
using AutoMapper;

namespace Academy.GestaoConteudo.Application.Services.Implements;

public class AulaService : IAulaService
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IAulaRepository _aulaRepository;
    private readonly IMapper _mapper;

    public AulaService(ICursoRepository cursoRepository, IAulaRepository aulaRepository, IMapper mapper)
    {
        _cursoRepository = cursoRepository;
        _aulaRepository = aulaRepository;
        _mapper = mapper;
    }

  
    public async Task<Guid> Criar(AulaDto auladto)
    {
        await Validar(auladto);

        var aula = _mapper.Map<Aula>(auladto);

        await _aulaRepository.Adicionar(aula);

        return aula.Id;
    }

    public async Task<IEnumerable<AulaDto>> ObterTodos()
    {
        var aula = await _aulaRepository.ObterTodos();
        return _mapper.Map<IEnumerable<AulaDto>>(aula);
    }

    public async Task<Guid> Atualizar(Guid aulaId, AulaDto aulaDto)
    {
        await Validar(aulaDto);

        var aula = await _aulaRepository.ObterEntidadePorFiltro(x => x.Id == aulaId);

        aula.AtualizarDados(
            titulo: aulaDto.Titulo,
            descricao: aulaDto.Descricao,
            videoUrl: aulaDto.VideoUrl,
            duracao: aulaDto.Duracao,
            ordem: aulaDto.Ordem,
            cursoId: aulaDto.CursoId
        );

        _aulaRepository.Atualizar(aula);

        return aula.Id;
    }



    public async Task Validar(AulaDto auladto)
    {

        var curso = await _cursoRepository.ObterEntidadePorFiltro(c => c.Id.Equals(auladto.CursoId));
        if (curso is null)
            throw new ArgumentException($"Não foi possivel encontrar o curso selecionado");

        var aulaExiste = await _aulaRepository.ObterEntidadePorFiltro(x => x.Titulo.Equals(auladto.Titulo) && x.CursoId.Equals(auladto.CursoId));
        if (aulaExiste is not null)
            throw new ArgumentException($"Aula já existe neste curso.");
    }
}
