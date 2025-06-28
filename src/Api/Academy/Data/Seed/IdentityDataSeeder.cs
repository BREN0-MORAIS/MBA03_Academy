using Academy.Api.Data.Const;
using Academy.Api.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Academy.Api.Data.Seed;

public class IdentityDataSeeder
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public IdentityDataSeeder(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task SeedAsync()
    {
        // Criação de Roles
        if (!await _roleManager.RoleExistsAsync(RoleNames.Administrador))
            await _roleManager.CreateAsync(new IdentityRole(RoleNames.Administrador));

        if (!await _roleManager.RoleExistsAsync(RoleNames.Aluno))
            await _roleManager.CreateAsync(new IdentityRole(RoleNames.Aluno));

        // Usuário Administrador
        var adminUser = await _userManager.FindByEmailAsync("admin@domain.com");
        if (adminUser == null)
        {
            adminUser = new ApplicationUser
            {
                UserName = "admin@domain.com",
                Email = "admin@domain.com",
                NomeCompleto= "Daniel Pereira",
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(adminUser, "Admin123!"); // Senha forte
            await _userManager.AddToRoleAsync(adminUser, RoleNames.Administrador);
        }

        // Usuário Aluno
        var studentUser = await _userManager.FindByEmailAsync("student@domain.com");
        if (studentUser == null)
        {
            studentUser = new ApplicationUser
            {
                UserName = "student@domain.com",
                Email = "student@domain.com",
                NomeCompleto = "Carlos Pereira",
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(studentUser, "Student123!");
            await _userManager.AddToRoleAsync(studentUser, RoleNames.Aluno);
        }
    }
}
