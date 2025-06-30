using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace Academy.Core.Events.ConsultaExterna.Implements;

public class MatriculaConsultaExterna : IMatriculaConsultaExterna
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public MatriculaConsultaExterna(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> AtivarMatricuala(Guid matriculaId)
    {
        var token = _httpContextAccessor.HttpContext?
            .Request.Headers["Authorization"]
            .ToString()
            .Replace("Bearer ", "", StringComparison.OrdinalIgnoreCase);

        if (string.IsNullOrWhiteSpace(token))
            return false;

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

        var body = new
        {
            matriculaId = matriculaId
        };

        var json = System.Text.Json.JsonSerializer.Serialize(body);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        // PUT na rota do endpoint
        var response = await _httpClient.PutAsync("/api/Matricula/AtivarMatricula", content);

        // Se quiser ver o status real (201 ou erro)
        if (!response.IsSuccessStatusCode)
        {
            var erro = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Erro ao ativar matrícula: {erro}");
            return false;
        }

        return true;
    }
}
