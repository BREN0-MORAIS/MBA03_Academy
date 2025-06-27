using Academy.GestaoConteudo.Data.Context;
using Academy.GestaoConteudo.Domain.Entities;
using Academy.GestaoConteudo.Domain.Enums;
using Academy.GestaoConteudo.Domain.ObjectValue;

namespace Academy.GestaoConteudo.Application.Seed;

public class GestaoConteudoSeed
{

    public static async Task InitializeAsync(GestaoConteudoContext context)
    {

        if (!context.Cursos.Any())
        {
            var conteudo = new ConteudoProgramatico("Full Stack .NET", "Curso completo de desenvolvimento com C# e ASP.NET");

            var curso = new Curso(
                "Formação Full Stack C#",
                "Aprenda do zero ao avançado em desenvolvimento .NET",
                CursoStatus.Ativo,
                499.90m,
                conteudo
            );

            context.Cursos.Add(curso);
            await context.SaveChangesAsync(); // Salva para gerar o cursoId

            var aulas = new List<Aula>
            {
                new Aula(
                    "Introdução ao C#",
                    "Conhecendo a linguagem e seu ecossistema",
                    "https://videosite.com/aulas/csharp-intro",
                    TimeSpan.FromMinutes(30),
                    1,
                    curso.Id
                ),
                new Aula(
                    "Programação Orientada a Objetos",
                    "Conceitos fundamentais de OOP com exemplos",
                    "https://videosite.com/aulas/oop",
                    TimeSpan.FromMinutes(45),
                    2,
                    curso.Id
                ),
                new Aula(
                    "Trabalhando com ASP.NET Core",
                    "Criando APIs REST com boas práticas",
                    "https://videosite.com/aulas/aspnet-core",
                    TimeSpan.FromMinutes(50),
                    3,
                    curso.Id
                )
            };

            context.Aulas.AddRange(aulas);
            await context.SaveChangesAsync();
        }
    }

 
}
