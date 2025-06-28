using Microsoft.AspNetCore.Identity;

namespace Academy.Api.Data.Models;

public class ApplicationUser : IdentityUser
{
    public string NomeCompleto { get; set; }
}