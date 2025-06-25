using Academy.GestaoConteudo.Application.DTOs;
using Academy.GestaoConteudo.Application.Services.Interfaces;
using Academy.GestaoConteudo.Domain.Interface;
using AutoMapper;

namespace Academy.GestaoConteudo.Application.Services.Implements;

public class AulaService : IAulaService
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IMapper _mapper;

    public AulaService(ICursoRepository cursoRepository, IMapper mapper)
    {
        _cursoRepository = cursoRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Atualizar(Guid AulaId, AulaDto cursoDto)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> Criar(AulaDto cursoDto)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<AulaDto>> ObterTodos()
    {
        throw new NotImplementedException();
    }
}
