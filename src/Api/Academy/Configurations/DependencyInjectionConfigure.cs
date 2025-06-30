using Academy.Api.Data;
using Academy.Core.Enuns;
using Academy.Core.Events.ConsultaExterna.Implements;
using Academy.GestaoAlunos.Application.Services.Implements;
using Academy.GestaoAlunos.Application.Services.Interfaces;
using Academy.GestaoAlunos.Application.Validators;
using Academy.GestaoAlunos.Data.Context;
using Academy.GestaoAlunos.Data.Repository;
using Academy.GestaoAlunos.Domain.Interface;
using Academy.GestaoConteudo.Application.Services.Implements;
using Academy.GestaoConteudo.Application.Services.Interfaces;
using Academy.GestaoConteudo.Data.Context;
using Academy.GestaoConteudo.Data.Repositories;
using Academy.GestaoConteudo.Data.Repository;
using Academy.GestaoConteudo.Domain.Interface;
using Academy.PagamentoFaturamento.Application.Services.Implements;
using Academy.PagamentoFaturamento.Application.Services.Interfaces;
using Academy.PagamentoFaturamento.Data.Context;
using Academy.PagamentoFaturamento.Data.Repository;
using Academy.PagamentoFaturamento.Domain.Geteway;
using Academy.PagamentoFaturamento.Domain.Repository;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;

namespace Academy.Api.Configurations;

public static class DependencyInjectionConfigure
{
    public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
    {
        RegistrarHttpClient(services);
        GestaoAlunos(services);
        GestaoConteudos(services);
        PagamentoFaturamento(services);
      
        return services;
    }

    public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration, DatabaseProvider provider)
    {
        string connectionString;

        switch (provider)
        {
            case DatabaseProvider.SqlServer:
                connectionString = configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<GestaoConteudoContext>(options =>
                    options.UseSqlServer(connectionString));

                services.AddDbContext<GestaoAlunosContext>(options =>
                    options.UseSqlServer(connectionString));

                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString));

                services.AddDbContext<PagamentoFaturamentoContext>(options =>
                    options.UseSqlServer(connectionString));
                break;

            case DatabaseProvider.Sqlite:
                connectionString = configuration.GetConnectionString("SqliteConnection");
                services.AddDbContext<GestaoConteudoContext>(options =>
                    options.UseSqlite(connectionString));

                services.AddDbContext<GestaoAlunosContext>(options =>
                    options.UseSqlite(connectionString));

                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlite(connectionString));

                services.AddDbContext<PagamentoFaturamentoContext>(options =>
                    options.UseSqlite(connectionString));
                break;

            default:
                throw new ArgumentException("Database provider not supported.");
        }

        return services;
    }



    private static void RegistrarHttpClient(IServiceCollection services)
    {
        var uri = "https://localhost:7179/api";

        services.AddHttpClient<ICursoConsultaExterna, CursoConsultaExterna>(client =>
        {
            client.BaseAddress = new Uri(uri);
        });

        services.AddHttpClient<IMatriculaConsultaExterna, MatriculaConsultaExterna>(client =>
        {
            client.BaseAddress = new Uri(uri);
        });

        services.AddHttpClient<IAulaConsultaExterna, AulaConsultaExterna>(client =>
        {
            client.BaseAddress = new Uri(uri);
        });
    }


    private static void GestaoAlunos(IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<MatriculaDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<AulaRealizadaDtoValidator>();

        services.AddScoped<IMatriculaRepository, MatriculaRepository>();
        services.AddScoped<IAulaRealizadaRepository, AulaRealizadaRepository>();
        services.AddScoped<IProgressoAlunoCursoRepository, ProgressoAlunoCursosRepository>();
        services.AddScoped<ICertificadoRepository, CertificadoRepository>();

        services.AddScoped<IMatriculaService, MatriculaService>();
        services.AddScoped<IAulaRealizadaService, AulaRealizadaService>();
        services.AddScoped<ICertificadoService, CertificadoService>();

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
