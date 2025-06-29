using Academy.Core.Exceptions;
using Academy.GestaoAlunos.Domain.Entities;
using Academy.GestaoAlunos.Domain.Enums;
using Academy.GestaoAlunos.Domain.Interface;
using Academy.PagamentoFaturamento.Application.Dto;
using Academy.PagamentoFaturamento.Application.Services.Interfaces;
using Academy.PagamentoFaturamento.Domain.Entities;
using Academy.PagamentoFaturamento.Domain.Enums;
using Academy.PagamentoFaturamento.Domain.Geteway;
using Academy.PagamentoFaturamento.Domain.Repository;
using Academy.PagamentoFaturamento.Domain.ValueObjects;
using AutoMapper;

namespace Academy.PagamentoFaturamento.Application.Services.Implements;

public class PagamentoService : IPagamentoService
{

    private IPagamentoRepository _pagamentoRepository;
    private IMatriculaRepository _matriculaRepository;
    private IGatewayPagamento _gatewayPagamento;
    private ICursoConsultaExterna _cursoConsultaExterna;
    private readonly IMapper _mapper;

    public PagamentoService(IPagamentoRepository pagamentoRepository, IMatriculaRepository matriculaRepository, IGatewayPagamento gatewayPagamento, ICursoConsultaExterna cursoConsultaExterna, IMapper mapper)
    {
        _pagamentoRepository = pagamentoRepository;
        _matriculaRepository = matriculaRepository;
        _gatewayPagamento = gatewayPagamento;
        _cursoConsultaExterna = cursoConsultaExterna;
        _mapper = mapper;
    }

    public async Task<string> Criar(PagamentoDto pagamentoDto, string userId)
    {

        var matricula = await _matriculaRepository.ObterPorId(pagamentoDto.MatriculaId);
        await Validar(pagamentoDto, userId, matricula);

        var dadosCartao = new DadosCartao(
                    pagamentoDto.NomeTitular,
                    pagamentoDto.NumeroCartaoCompleto,
                    pagamentoDto.Expiracao,
                    pagamentoDto.Cvv,
                    pagamentoDto.Bandeira);



        var curso =await _cursoConsultaExterna.ObterCursoDetalhadoAsync(matricula.CursoId);

       var processarPagamento = await _gatewayPagamento.ProcessarPagamento(
            pagamentoDto.MatriculaId, 
            pagamentoDto.Valor,
            curso.Valor,
            dadosCartao );

        if (!processarPagamento.Sucesso) return processarPagamento.Mensagem;


        var pagamento = new Pagamento(
            pagamentoDto.NomeTitular,
            pagamentoDto.MatriculaId,
            pagamentoDto.Valor,
            pagamentoDto.MeioPagamento,
            dadosCartao,
            processarPagamento.TransacaoId,
            processarPagamento.Mensagem,
            pagamentoDto.Bandeira
            );

        pagamento.Confirmar();
        await _pagamentoRepository.Adicionar(pagamento);

        return processarPagamento.Mensagem;
    }

    public async Task Validar(PagamentoDto pagamentoDto, string userId, Matricula matricula)
    {
        if (!matricula.UserId.Equals(userId)) throw new DomainException("Usuário não cadastrado para esta Matricula.");
        if (matricula is null) throw new DomainException("Matricula não cadastrada");
        if (matricula.Status.Equals(MatriculaStatus.Inativo)) throw new DomainException("Matricula inativa ou pendente pagamento.");
    }
}
