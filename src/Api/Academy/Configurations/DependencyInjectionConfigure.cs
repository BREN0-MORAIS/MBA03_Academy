using Academy.GestaoConteudo.Application.Services;
using Academy.GestaoConteudo.Application.Services.Interfaces;
using Academy.GestaoConteudo.Data.Repositories;
using Academy.GestaoConteudo.Domain.Interface;

namespace Academy.Api.Configurations;

public static class DependencyInjectionConfigure
{
    public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
    {

        AddRepositories(services);

        return services;
    }

    private static void AddRepositories(IServiceCollection services)
    {
   


        services.AddScoped<ICursoRepository, CursoRepository>();
        services.AddScoped<ICursoService, CursoService>();




    }
}
