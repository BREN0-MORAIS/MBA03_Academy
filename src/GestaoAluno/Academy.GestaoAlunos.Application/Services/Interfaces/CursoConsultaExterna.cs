using System.Net.Http.Headers;
using Academy.GestaoAlunos.Application.Services.Implements;
using Microsoft.AspNetCore.Http;

namespace Academy.GestaoAlunos.Application.Services.Interfaces;

public class CursoConsultaExterna : ICursoConsultaExterna
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CursoConsultaExterna(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> CursoExisteAsync(Guid cursoId)
    {
        var token = _httpContextAccessor.HttpContext?
            .Request
            .Headers["Authorization"]
            .ToString()
            .Replace("Bearer ", "", StringComparison.OrdinalIgnoreCase);

        if (string.IsNullOrWhiteSpace(token))
            return false;

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.GetAsync($"/api/Curso/ObterCursoAtivoPorId/{cursoId}");

        var content = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrEmpty(content))
        {
            return false;
        }
        return response.IsSuccessStatusCode;
    }
}
