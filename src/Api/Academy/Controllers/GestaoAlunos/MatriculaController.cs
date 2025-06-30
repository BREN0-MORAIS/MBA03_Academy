using Academy.Api.Data.Const;
using Academy.Api.Enums.GestaoConteudo;
using Academy.GestaoAlunos.Application.CQRS.Commands.AtivarMatricula;
using Academy.GestaoAlunos.Application.CQRS.Commands.CriarMatricula;
using Academy.GestaoAlunos.Application.CQRS.Commands.FinalizarCurso;
using Academy.GestaoAlunos.Application.CQRS.Queries.ObterTodasMinhasMatriculas;
using Academy.GestaoAlunos.Application.Dtos;
using Academy.GestaoConteudo.Application.CQRS.Commands.AtualizarCurso;
using Academy.GestaoConteudo.Application.CQRS.Commands.CriarCurso;
using Academy.GestaoConteudo.Application.CQRS.Queries.ObterCursoPorId;
using Academy.GestaoConteudo.Application.CQRS.Queries.ObterTodosCursos;
using Academy.GestaoConteudo.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Api.Controllers.GestaoAlunos;

[Route("api/[controller]")]
[ApiController]
public class MatriculaController : ControllerBase
{
    private readonly IMediator _mediator;

    public MatriculaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = RoleNames.Aluno)]
    [HttpPost("CriarMatricula")]
    [ProducesResponseType(typeof(CriarCursoCommand), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CriarMatricula([FromBody] CriarMatriculaDto matricula)
    {
        var userIdentityId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var command = new CriarMatriculaCommand (cursoId: matricula.CursoId, userId: userIdentityId);

        return CreatedAtAction(
            nameof(CriarMatricula),
            new { id = await _mediator.Send(command) }
        );
    }


    [Authorize(Roles = RoleNames.Aluno)]
    [HttpPut("FinalizarCurso", Name = "FinalizarCurso")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> FinalizarCurso([FromBody] FinalizarCursoRequest matricula)
    {
        var userIdentityId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var command = new FinalizarCursoCommand(matricula.MatriculaId,  userIdentityId);
        return CreatedAtAction(
            nameof(FinalizarCurso),
            new { id = await _mediator.Send(command) }
        );
    }


    [Authorize(Roles = RoleNames.Aluno)]
    [HttpPut("AtivarMatricula", Name = "AtivarMatricula")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AtivarMatricula([FromBody] FinalizarCursoRequest matricula)
    {
        var userIdentityId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var command = new AtivarMatriculaCommand(matricula.MatriculaId, userIdentityId);
        return CreatedAtAction(
            nameof(AtivarMatricula),
            new { id = await _mediator.Send(command) }
        );
    }

    [Authorize]
    [HttpGet("ObterTodasMinhasMatriculas")]
    public async Task<IActionResult> ObterTodasMinhasMatriculas()
    {
        var userIdentityId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (!ModelState.IsValid)
        return BadRequest(ModelState);
        var matriculas = await _mediator.Send(new ObterTodasMinhasMatriculasQuery(userIdentityId));
        return Ok(matriculas);
    }

    //    [Authorize(Roles = RoleNames.Administrador)]
    //    [HttpPut("AtualizarCurso/{id:guid}", Name = "AtualizarCurso")]
    //    [ProducesResponseType(StatusCodes.Status204NoContent)]
    //    [ProducesResponseType(StatusCodes.Status404NotFound)]
    //    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //    public async Task<IActionResult> AtualizarCurso(Guid id, [FromBody] CursoDto cursoDto)
    //    {
    //        if (!ModelState.IsValid)
    //            return BadRequest(ModelState);

    //        var command = new AtualizarCursoCommand(
    //            id,
    //            cursoDto.Titulo,
    //            cursoDto.Descricao,
    //            cursoDto.Status,
    //            cursoDto.Valor,
    //            cursoDto.Objetivo,
    //            cursoDto.PreRequisitos);

    //        await _mediator.Send(command);
    //        return NoContent();
    //    }

    //    [Authorize(Roles = RoleNames.Aluno)]
    //    [HttpGet("ObterTodosCursosAtivo")]
    //    public async Task<IActionResult> ObterTodosCursosAtivo()
    //    {
    //        var cursos = await _mediator.Send(new ObterTodosCursosQuery { Status = (int)ObterCursoPorStatus.Ativo });
    //        return Ok(cursos);
    //    }

    //    [Authorize(Roles = RoleNames.Administrador)]
    //    [HttpGet("ObterTodosCursos")]
    //    public async Task<IActionResult> ObterTodosCursos()
    //    {
    //        var cursos = await _mediator.Send(new ObterTodosCursosQuery { Status = (int)ObterCursoPorStatus.Todos });
    //        return Ok(cursos);
    //    }

    //    [Authorize(Roles = RoleNames.Administrador)]
    //    [HttpGet("ObterCursoPorId/{id:guid}")]
    //    public async Task<IActionResult> ObterCursoPorId(Guid id)
    //    {
    //        var cursos = await _mediator.Send(new ObterCursoPorIdQuery { Id = id });
    //        return Ok(cursos);
    //    }
}
