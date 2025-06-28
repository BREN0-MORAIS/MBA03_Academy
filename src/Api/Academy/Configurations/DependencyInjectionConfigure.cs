using Academy.GestaoAlunos.Application.Services.Implements;
using Academy.GestaoAlunos.Application.Services.Interfaces;
using Academy.GestaoAlunos.Data.Repository;
using Academy.GestaoAlunos.Domain.Interface;
using Academy.GestaoConteudo.Application.Services.Implements;
using Academy.GestaoConteudo.Application.Services.Interfaces;
using Academy.GestaoConteudo.Data.Repositories;
using Academy.GestaoConteudo.Data.Repository;
using Academy.GestaoConteudo.Domain.Interface;

namespace Academy.Api.Configurations;

public static class DependencyInjectionConfigure
{
    public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
    {
        GestaoAlunos(services);
        GestaoConteudos(services);
        return services;
    }

    private static void GestaoAlunos(IServiceCollection services)
    {
        //services.AddValidatorsFromAssemblyContaining<CursoDTOValidator>();
        //services.AddValidatorsFromAssemblyContaining<AulaDtoValidator>();

        services.AddScoped<IMatriculaRepository, MatriculaRepository>();

        services.AddHttpClient<ICursoConsultaExterna, CursoConsultaExterna>(client =>
        {
            client.BaseAddress = new Uri("https://localhost:7179/api");
        });


        services.AddScoped<IMatriculaService, MatriculaService>();


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
}
