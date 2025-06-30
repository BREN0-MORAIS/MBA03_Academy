using Academy.Api.Configurations;
using Academy.Api.Data;
using Academy.Api.Data.Models;
using Academy.Api.Data.Seed;
using Academy.Core.Enuns;
using Academy.GestaoAlunos.Application.AutorMapper;
using Academy.GestaoAlunos.Application.CQRS.Commands.CriarMatricula;
using Academy.GestaoAlunos.Data.Context;
using Academy.GestaoConteudo.Application.AutorMapper;
using Academy.GestaoConteudo.Application.CQRS.Commands.CriarCurso;
using Academy.GestaoConteudo.Application.Seed;
using Academy.GestaoConteudo.Data.Context;
using Academy.PagamentoFaturamento.Application.AutoMapper;
using Academy.PagamentoFaturamento.Application.CQRS.Commands.RealizarPagamento;
using Academy.PagamentoFaturamento.Data.Context;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 1️⃣ CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// 2️⃣ FluentValidation
builder.Services.AddFluentValidationAutoValidation();

// 3️⃣ Swagger com suporte ao Bearer Token
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Academy API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header usando o esquema Bearer. Ex: 'Bearer {seu_token}'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// AutoMapper, MediatR
builder.Services.ConfigureDependencyInjection();

builder.Services.AddAutoMapper(typeof(GestaoConteudoMap).Assembly);
builder.Services.AddAutoMapper(typeof(GestaoAlunoMap).Assembly);
builder.Services.AddAutoMapper(typeof(PagamentoFaturamentoMap).Assembly);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CriarCursoCommand).Assembly));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CriarMatriculaCommand).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RealizarPagamentoCommand).Assembly));

// Contexts


var providerString = builder.Configuration["DatabaseProvider"];
var provider = Enum.Parse<DatabaseProvider>(providerString);

builder.Services.ConfigureDatabase(builder.Configuration, provider);


//  Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// JWT Authentication
var secret = builder.Configuration["JwtSettings:Secret"];
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<JwtSettings>(appSettingsSection);

var appSettings = appSettingsSection.Get<JwtSettings>();
builder.Services.AddSingleton(appSettings);

var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = true;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = appSettings.Audience,
            ValidIssuer = appSettings.Issuer
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddControllers();

// 8️⃣ Build app
var app = builder.Build();

// 9️⃣ Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

// Debug do header Authorization
app.Use(async (context, next) =>
{
    var auth = context.Request.Headers["Authorization"].ToString();
    Console.WriteLine($"🔐 Authorization Header: {auth}");
    await next();
});

//   Seed dos dados (Roles e Usuários)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<GestaoConteudoContext>();
    await GestaoConteudoSeed.InitializeAsync(context);

    var seeder = new IdentityDataSeeder(
        services.GetRequiredService<UserManager<ApplicationUser>>(),
        services.GetRequiredService<RoleManager<IdentityRole>>());

    await seeder.SeedAsync();
}

//  Middleware
app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
