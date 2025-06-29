using Academy.GestaoConteudo.Application.Dtos;
using Academy.GestaoConteudo.Application.Services.Interfaces;
using Academy.GestaoConteudo.Domain.Entities;
using Azure.Core;
using MediatR;

namespace Academy.GestaoConteudo.Application.CQRS.Commands.CriarCurso;

public class CriarCursoHandler : IRequestHandler<CriarCursoCommand, Guid>
{
    private readonly ICursoService _cursoService;

    public CriarCursoHandler(ICursoService cursoService)
    {
        _cursoService = cursoService;
    }

    public async Task<Guid> Handle(CriarCursoCommand request, CancellationToken cancellationToken)
    {
        var cursoDto = Mapear(request);
        var cursoId = await _cursoService.Criar(cursoDto);

        return cursoId;
    }

    public CriarCursoDto Mapear(CriarCursoCommand request)
    {
        var cursoDto = new CriarCursoDto
        {
            Titulo = request.Titulo,
            Descricao = request.Descricao,
            Objetivo = request.Objetivo,
            PreRequisitos = request.PreRequisitos,
            Status = request.Status,
            Valor = request.Valor
        };

        return cursoDto;
    }
}
