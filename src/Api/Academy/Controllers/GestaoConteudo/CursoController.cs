using Academy.Api.Data.Const;
using Academy.Api.Enums.GestaoConteudo;
using Academy.GestaoConteudo.Application.CQRS.Commands.AtualizarCurso;
using Academy.GestaoConteudo.Application.CQRS.Commands.CriarCurso;
using Academy.GestaoConteudo.Application.CQRS.Queries.ObterCursoPorId;
using Academy.GestaoConteudo.Application.CQRS.Queries.ObterTodosCursos;
using Academy.GestaoConteudo.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Api.Controllers.GestaoConteudo
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CursoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = RoleNames.Administrador)]
        [HttpPost("CriarCurso")]
        [ProducesResponseType(typeof(CriarCursoCommand), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CriarCurso([FromBody] CriarCursoDto cursoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CriarCursoCommand(
                    titulo: cursoDto.Titulo,
                    descricao: cursoDto.Descricao,
                    status: cursoDto.Status,
                    valor: cursoDto.Valor,
                    objetivo: cursoDto.Objetivo,
                    preRequisitos: cursoDto.PreRequisitos);

            return CreatedAtAction(
                nameof(CriarCurso),
                new { id = await _mediator.Send(command) }
            );
        }
        [Authorize(Roles = RoleNames.Administrador)]
        [HttpPut("AtualizarCurso/{id:guid}", Name = "AtualizarCurso")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AtualizarCurso(Guid id, [FromBody] CursoDto cursoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new AtualizarCursoCommand(
                id,
                cursoDto.Titulo,
                cursoDto.Descricao,
                cursoDto.Status,
                cursoDto.Valor,
                cursoDto.Objetivo,
                cursoDto.PreRequisitos);

            await _mediator.Send(command);
            return NoContent();
        }

        [Authorize(Roles = RoleNames.Aluno)]
        [HttpGet("ObterTodosCursosAtivo")]
        public async Task<IActionResult> ObterTodosCursosAtivo()
        {
            var cursos = await _mediator.Send(new ObterTodosCursosQuery{ Status = (int) ObterCursoPorStatus.Ativo});
            return Ok(cursos);
        }

        [Authorize(Roles = RoleNames.Administrador)]
        [HttpGet("ObterTodosCursos")]
        public async Task<IActionResult> ObterTodosCursos()
        {
            var cursos = await _mediator.Send(new ObterTodosCursosQuery { Status = (int)ObterCursoPorStatus.Todos});
            return Ok(cursos);
        }

        [Authorize(Roles = RoleNames.Administrador)]
        [HttpGet("ObterCursoPorId/{id:guid}")]
        public async Task<IActionResult> ObterCursoPorId(Guid id)
        {
            var cursos = await _mediator.Send(new ObterCursoPorIdQuery { Id = id });
            return Ok(cursos);
        }

        [Authorize]
        [HttpGet("ObterCursoAtivoPorId/{id:guid}")]
        public async Task<IActionResult> ObterCursoAtivoPorId(Guid id)
        {
            var cursos = await _mediator.Send(new ObterCursoPorIdQuery { Id = id });
            return Ok(cursos);
        }
    }
}
