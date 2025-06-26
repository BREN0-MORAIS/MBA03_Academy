using Academy.GestaoConteudo.Application.CQRS.Commands.AtualizarAula;
using Academy.GestaoConteudo.Application.CQRS.Commands.AtualizarCurso;
using Academy.GestaoConteudo.Application.CQRS.Commands.CriarAula;
using Academy.GestaoConteudo.Application.CQRS.Commands.CriarCurso;
using Academy.GestaoConteudo.Application.CQRS.Queries.ObterTodosCursos;
using Academy.GestaoConteudo.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Api.Controllers.GestaoConteudo
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AulaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CriarAula")]
        [ProducesResponseType(typeof(CriarCursoCommand), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CriarAula([FromBody] AulaDto aulaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CriarAulaCommand(
                aulaDto.Titulo,
                aulaDto.Descricao,
                aulaDto.VideoUrl,
               TimeSpan.FromMinutes(10),
                aulaDto.Ordem,
                aulaDto.CursoId
                );

            return CreatedAtAction(
                nameof(CriarAula),
                new { id = await _mediator.Send(command) }
            );
        }


        [HttpPut("AtualizarAula/{id:guid}", Name = "AtualizarAula")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AtualizarAula(Guid id, [FromBody] AulaDto aulaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new AtualizarAulaCommand(
                id,
                aulaDto.Titulo,
                aulaDto.Descricao,
                aulaDto.VideoUrl,
               TimeSpan.FromMinutes(10),
                aulaDto.Ordem,
                aulaDto.CursoId
            );

            await _mediator.Send(command);
            return NoContent();
        }
    }
}
