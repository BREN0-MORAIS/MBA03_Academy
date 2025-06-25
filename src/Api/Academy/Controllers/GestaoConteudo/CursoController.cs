using Academy.GestaoConteudo.Application.CQRS.Commands.AtualizarCurso;
using Academy.GestaoConteudo.Application.CQRS.Commands.CriarCurso;
using Academy.GestaoConteudo.Application.CQRS.Queries.ObterTodosCursos;
using Academy.GestaoConteudo.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
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

        [HttpPost(Name = "CriarCurso")]
        [ProducesResponseType(typeof(CriarCursoCommand), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CriarCurso([FromBody] CursoDto cursoDto)
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
        [HttpPut("{id:guid}", Name = "AtualizarCurso")]
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

        [HttpGet(Name = "ObterTodosCursos")]
        public async Task<IActionResult> ObterTodosCursos()
        {
            var cursos = await _mediator.Send(new ObterTodosCursosQuery());
            return Ok(cursos);
        }
    }
}
