using Microsoft.AspNetCore.Identity;

namespace Academy.Api.Models;

public class ApplicationUser : IdentityUser
{
    public string NomeCompleto { get; set; }
}