using Academy.Api.Data.Const;
using Academy.GestaoConteudo.Application.CQRS.Commands.CriarCurso;
using Academy.GestaoConteudo.Application.Dtos;
using Academy.PagamentoFaturamento.Application.CQRS.Commands.RealizarPagamento;
using Academy.PagamentoFaturamento.Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Api.Controllers.PagamentoFaturamento
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PagamentoController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [Authorize(Roles = RoleNames.Aluno)]
        [HttpPost("RealizarPagamento")]
        [ProducesResponseType(typeof(CriarCursoCommand), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RealizarPagamento([FromBody] PagamentoDto pagamentoDto)
        {
            var userIdentityId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new RealizarPagamentoCommand(
                            pagamentoDto.MatriculaId,
                            pagamentoDto.Valor,
                            pagamentoDto.NomeTitular,
                            pagamentoDto.NumeroCartaoCompleto,
                            pagamentoDto.Expiracao,
                            pagamentoDto.Cvv,
                            pagamentoDto.Bandeira,
                            pagamentoDto.MeioPagamento,
                            userIdentityId
                );


            return CreatedAtAction(
                nameof(RealizarPagamento),
                new { id = await _mediator.Send(command) }
            );
        }
    }
}
