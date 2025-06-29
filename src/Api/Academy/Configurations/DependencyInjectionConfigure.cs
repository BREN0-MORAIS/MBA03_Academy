using Academy.GestaoAlunos.Application.Services.Implements;
using Academy.GestaoAlunos.Application.Services.Interfaces;
using Academy.GestaoAlunos.Application.Validators;
using Academy.GestaoAlunos.Data.Repository;
using Academy.GestaoAlunos.Domain.Interface;
using Academy.GestaoConteudo.Application.Services.Implements;
using Academy.GestaoConteudo.Application.Services.Interfaces;
using Academy.GestaoConteudo.Data.Repositories;
using Academy.GestaoConteudo.Data.Repository;
using Academy.GestaoConteudo.Domain.Interface;
using Academy.PagamentoFaturamento.Application.Services.Implements;
using Academy.PagamentoFaturamento.Application.Services.Interfaces;
using Academy.PagamentoFaturamento.Data.Repository;
using Academy.PagamentoFaturamento.Domain.Geteway;
using Academy.PagamentoFaturamento.Domain.Repository;
using FluentValidation;

namespace Academy.Api.Configurations;

public static class DependencyInjectionConfigure
{
    public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
    {
        GestaoAlunos(services);
        GestaoConteudos(services);
        PagamentoFaturamento(services);
        return services;
    }

    private static void GestaoAlunos(IServiceCollection services)
    {
        var uri = "https://localhost:7179/api";
        services.AddValidatorsFromAssemblyContaining<MatriculaDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<AulaRealizadaDtoValidator>();

        services.AddScoped<IMatriculaRepository, MatriculaRepository>();
        services.AddScoped<IAulaRealizadaRepository, AulaRealizadaRepository>();
        services.AddScoped<IProgressoAlunoCursoRepository, ProgressoAlunoCursosRepository>();

        services.AddHttpClient<ICursoConsultaExterna, CursoConsultaExterna>(client =>
        {
            client.BaseAddress = new Uri(uri);
        });



        services.AddHttpClient<IAulaConsultaExterna, AulaConsultaExterna>(client =>
         {
             client.BaseAddress = new Uri(uri);
         });

        services.AddScoped<IMatriculaService, MatriculaService>();
        services.AddScoped<IAulaRealizadaService, AulaRealizadaService>();


        //services.AddScoped<ICursoService, CursoService>();
        //services.AddScoped<IAulaService, AulaService>();

    }

    private static void GestaoConteudos(IServiceCollection services)
    {
        services.AddScoped<ICursoRepository, CursoRepository>();
        services.AddScoped<IAulaRepository, AulaRepository>();

        services.AddScoped<ICursoService, CursoService>();
        services.AddScoped<IAulaService, AulaService>();

    }

    private static void PagamentoFaturamento(IServiceCollection services)
    {
        services.AddScoped<IGatewayPagamento, GatewayPagamentoSimulado>();
        services.AddScoped<IPagamentoRepository, PagamentoRepository>();
        services.AddScoped<IPagamentoService, PagamentoService>();
    }
}
