using Academy.GestaoConteudo.Application.Services.Interfaces;
using Academy.GestaoConteudo.Application.Validators;
using Academy.GestaoConteudo.Domain.Entities;
using Academy.GestaoConteudo.Domain.Interface;
using AutoMapper;

namespace Academy.GestaoConteudo.Application.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IMapper _mapper;

        public CursoService(ICursoRepository cursoRepository, IMapper mapper)
        {
            _cursoRepository = cursoRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Criar(CursoDto cursoDto)
        {
            var cursoExiste = await _cursoRepository.ObterEntidadePorFiltro(c => c.Titulo.Equals(cursoDto.Titulo));
            if (cursoExiste is not null) throw new ArgumentException($"Ja existe um curso com este nome {cursoDto.Titulo}");

            var curso = _mapper.Map<Curso>(cursoDto);

            await _cursoRepository.Adicionar(curso);
            return Guid.NewGuid();
        }
        public async Task<IEnumerable<CursoDto>> ObterTodos()
        {
            var cursos = await _cursoRepository.ObterTodos();
            return _mapper.Map<IEnumerable<CursoDto>>(cursos);
        }

        public async Task<Guid> Atualizar(Guid CursoId,CursoDto cursoDto)
        {
            var curso = await _cursoRepository.ObterEntidadePorFiltro(c => c.Id.Equals(CursoId));
            if (curso is null)
                throw new ArgumentException($"O Curso não existe");

            curso.AtualizarDados(
                titulo: cursoDto.Titulo,
                descricao: cursoDto.Descricao,
                status: cursoDto.Status,
                valor: cursoDto.Valor,
                objetivo: cursoDto.Objetivo,
                preRequisitos: cursoDto.PreRequisitos
            );

            _cursoRepository.Atualizar(curso); 

            return curso.Id;
        }

    }
}