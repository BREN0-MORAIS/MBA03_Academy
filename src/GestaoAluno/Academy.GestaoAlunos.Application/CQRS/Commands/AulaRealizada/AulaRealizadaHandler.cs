using Academy.GestaoAlunos.Application.CQRS.Commands.CriarMatricula;
using Academy.GestaoAlunos.Application.Dtos;
using Academy.GestaoAlunos.Application.Services.Interfaces;
using MediatR;

namespace Academy.GestaoAlunos.Application.CQRS.Commands.AulaRealizada;

public class AulaRealizadaHandler : IRequestHandler<AulaRealizadaCommand, Guid>
{
    public AulaRealizadaHandler(IAulaRealizadaService aulaRealizadaService)
    {
        _aulaRealizadaService = aulaRealizadaService;
    }

    public IAulaRealizadaService _aulaRealizadaService { get; set; }
    public async Task<Guid> Handle(AulaRealizadaCommand request, CancellationToken cancellationToken)
    {
       return await _aulaRealizadaService.Criar(
           Mapear(request)
           );
    }

    public AulaRealizadaDto Mapear(AulaRealizadaCommand request)
    {
        return new AulaRealizadaDto { MatriculaId = request.MatriculaId, AulaId = request.AulaId };
    }
}
