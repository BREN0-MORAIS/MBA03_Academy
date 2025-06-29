using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;



public class AulaConsultaExterna : IAulaConsultaExterna
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AulaConsultaExterna(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> AulaExisteAsync(Guid aulaId)
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

        var response = await _httpClient.GetAsync($"/api/Aula/ObterAulaAtivaPorId/{aulaId}");

        var content = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrEmpty(content))
        {
            return false;
        }
        return response.IsSuccessStatusCode;
    }
}
