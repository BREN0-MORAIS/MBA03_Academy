using Academy.Api.Data.Const;
using Academy.GestaoAlunos.Application.CQRS.Commands.AulaRealizada;
using Academy.GestaoAlunos.Application.Dtos;
using Academy.GestaoConteudo.Application.CQRS.Commands.AtualizarAula;
using Academy.GestaoConteudo.Application.CQRS.Commands.CriarAula;
using Academy.GestaoConteudo.Application.CQRS.Commands.CriarCurso;
using Academy.GestaoConteudo.Application.CQRS.Queries.ObterAulaAtivaPorId;
using Academy.GestaoConteudo.Application.CQRS.Queries.ObterAulasPorCursoId;
using Academy.GestaoConteudo.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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


        [Authorize]
        [HttpGet("ObterAulaAtivaPorId/{aulaId:guid}")]
        public async Task<IActionResult> ObterAulaAtivaPorId(Guid aulaId)
        {
            var aula = await _mediator.Send(new ObterAulaAtivaPorIdQuery { AulaId = aulaId });
            return Ok(aula);
        }

        [Authorize]
        [HttpGet("ObterAulasPorCursoId/{cursoId:guid}")]
        public async Task<IActionResult> ObterAulasPorCursoId(Guid cursoId)
        {
            var aula = await _mediator.Send(new ObterAulasPorCursoIdQuery { CursoId = cursoId });
            return Ok(aula);
        }


        [Authorize(Roles = RoleNames.Administrador)]
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

        [Authorize(Roles = RoleNames.Aluno)]
        [HttpPost("RealizarAula")]
        [ProducesResponseType(typeof(CriarCursoCommand), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RealizarAula([FromBody] AulaRealizadaAdicionarDto aulaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new AulaRealizadaCommand(
                  aulaDto.MatriculaId,
                  aulaDto.AulaId
                );

            return CreatedAtAction(
                nameof(CriarAula),
                new { id = await _mediator.Send(command) }
            );
        }


        [Authorize(Roles = RoleNames.Administrador)]
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
