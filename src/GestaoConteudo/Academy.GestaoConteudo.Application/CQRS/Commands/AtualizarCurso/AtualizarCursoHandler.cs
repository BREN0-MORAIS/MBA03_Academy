using Academy.GestaoConteudo.Application.CQRS.Commands.CriarCurso;
using Academy.GestaoConteudo.Application.Services.Interfaces;
using Academy.GestaoConteudo.Application.Validators;
using Academy.GestaoConteudo.Domain.Interface;
using MediatR;

namespace Academy.GestaoConteudo.Application.CQRS.Commands.AtualizarCurso;

public class AtualizarCursoHandler : IRequestHandler<AtualizarCursoCommand, Guid>
{

    private readonly ICursoService _cursoService;

    public AtualizarCursoHandler(ICursoService cursoService)
    {
        _cursoService = cursoService;
    }

    public async Task<Guid> Handle(AtualizarCursoCommand request, CancellationToken cancellationToken)
    {
        var cursoDto = Mapear(request);
        var cursoId = await _cursoService.Atualizar(request.Id, cursoDto);

        return cursoId;
    }

    public CursoDto Mapear(AtualizarCursoCommand request)
    {
        var cursoDto = new CursoDto
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
