using GestionProvedores.Config;
using GestionProvedores.Exceptions;
using GestionProvedores.Repositories.Impl;
using GestionProvedores.Repositories;
using GestionProvedores.Services;
using GestionProvedores.Services.Impl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 100 * 1024 * 1024; // 10 MB
});
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];

// Configuraciones de CORS desde appsettings.json
var corsAllowedOrigins = builder.Configuration["Cors:AllowedOrigins"];
var corsAllowedHeaders = builder.Configuration["Cors:AllowedHeaders"];
var corsAllowedMethods = builder.Configuration["Cors:AllowedMethods"];


builder.Services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddHttpContextAccessor();
// Add services to the container.


builder.Services.AddScoped<IHeaderService, HeaderService>();

builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IMasterService, MasterService>();
builder.Services.AddScoped<IMasterRepository, MasterRepository>();

builder.Services.AddScoped<IProveedorService, ProveedorService>();
builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();

builder.Services.AddScoped<IUbicacionService, UbicacionService>();
builder.Services.AddScoped<IUbicacionRepository, UbicacionRepository>();

builder.Services.AddScoped<IPerfilService, PerfilService>();
builder.Services.AddScoped<IPerfilRepository, PerfilRepository>();

////
builder.Services.AddScoped<ICatalogoService, CatalogoServiceImpl>();
builder.Services.AddScoped<ICatalogoRepository, CatalogoRepository>();

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddScoped<IHttpErpService, HttpErpService>();

builder.Services.AddScoped<ICuentaService, CuentaService>();
builder.Services.AddScoped<ICuentaRepository, CuentaRepository>();

builder.Services.AddScoped<IMarcaService, MarcaService>();
builder.Services.AddScoped<IMarcaRepository, MarcaRepository>();

builder.Services.AddScoped<IPersonaService, PersonaService>();
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();

builder.Services.AddScoped<IEncuestaService, EncuestaService>();
builder.Services.AddScoped<IEncuestaRepository, EncuestaRepository>();

builder.Services.AddScoped<IDescargarService, DescargarService>();
builder.Services.AddScoped<IDescargarRepository, DescargarRepository>();


builder.Services.AddScoped<ICorreoService, CorreoService>();

builder.Services.AddScoped<IHttpSunatService, HttpSunatService>();
builder.Services.AddScoped<IHttpApisService, HttpApisService>();




builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtIssuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtKey!))
        };
    });

builder.Services.AddExceptionHandler<ManagerExceptionHandler>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowConfiguredOrigins",
        builder =>
        {
            builder.WithOrigins(corsAllowedOrigins.Split(","))
                   .WithHeaders(corsAllowedHeaders.Split(","))
                   .WithMethods(corsAllowedMethods.Split(","));
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Proveedores Api", Version = "v1" });

    // Define the OAuth2.0 scheme that's in use (i.e., Implicit Flow)
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline
//if (app.Environment.IsDevelopment())
//{
//}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStatusCodePages();

app.UseCors("AllowConfiguredOrigins");

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseExceptionHandler("/error");

app.Run();
