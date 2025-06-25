using Academy.GestaoConteudo.Application.Services.Implements;
using Academy.GestaoConteudo.Application.Services.Interfaces;
using Academy.GestaoConteudo.Application.Validators;
using Academy.GestaoConteudo.Data.Repositories;
using Academy.GestaoConteudo.Data.Repository;
using Academy.GestaoConteudo.Domain.Interface;
using FluentValidation;

namespace Academy.Api.Configurations;

public static class DependencyInjectionConfigure
{
    public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CursoDTOValidator>();
        services.AddValidatorsFromAssemblyContaining<AulaDtoValidator>();

        AddRepositories(services);

        return services;
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<ICursoRepository, CursoRepository>();
        services.AddScoped<IAulaRepository, AulaRepository>();

        services.AddScoped<ICursoService, CursoService>();
        services.AddScoped<IAulaService, AulaService>();

    }
}
