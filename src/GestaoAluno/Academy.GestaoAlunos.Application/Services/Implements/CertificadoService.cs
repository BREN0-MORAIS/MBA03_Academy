using Academy.Core.Exceptions;
using Academy.GestaoAlunos.Application.Dtos;
using Academy.GestaoAlunos.Application.Services.Interfaces;
using Academy.GestaoAlunos.Domain.Entities;
using Academy.GestaoAlunos.Domain.Interface;

namespace Academy.GestaoAlunos.Application.Services.Implements;

public class CertificadoService : ICertificadoService
{
    public CertificadoService(ICertificadoRepository certificadoRepository, ICursoConsultaExterna cursoConsultaExterna)
    {
        _certificadoRepository = certificadoRepository;
        _cursoConsultaExterna = cursoConsultaExterna;
    }
    private ICertificadoRepository _certificadoRepository;
    private ICursoConsultaExterna _cursoConsultaExterna;


    public async Task<string> GerarCertificado(Matricula matricula, string NomeAluno)
    {
        if (matricula is null) throw new DomainException("dados da matricula não pode ser nulo.");

        var curso = await _cursoConsultaExterna.ObterCursoDetalhadoAsync(matricula.CursoId);

        if (curso is null) throw new DomainException("Matricula não existe para este curso");

      var certificado =  await  _certificadoRepository.Adicionar(new Certificado(
                matricula.UserId,
                matricula.CursoId,
                matricula.Id,
                NomeAluno,
                curso.Titulo
            ));

        return "Certificado disponivel para consulta: "+ certificado.Id;
    }
}
