using Aplication.Mapper.Configuration;
using Aplication.Mapper.Employee;
using Aplication.Mapper.Employee.Interfaces;
using Aplication.Security.Interfaz;
using Aplication.Security;
using Aplication.Services;
using Aplication.Services.Interfaces;
using Domain.Interfaces;
using Infraestructure.Api.Controllers;
using Infraestructure.Api.Controllers.Interfaces;
using Infraestructure.Data.Repository.ExternalApis.Employee;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Aplication.Security.Option;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infraestructure.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddAutoMapper(typeof(ConfigurationMapperProfile));
            services.AddScoped<IEmployeeController, EmployeeController>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IApiClientEmployeeRepository, ApiClientEmployeeRepository>();
            services.AddHttpClient<ApiClientEmployeeRepository>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });
            services.Configure<JwtOptions>(_configuration.GetSection("JwtOptions"));

            // Cargar opciones de JWT desde appsettings.json
            var jwtOptions = _configuration.GetSection("JwtOptions").Get<JwtOptions>();

            // Configurar esquema de autenticación JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options =>
      {
          // Configuración del token JWT
          options.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuer = true,
              ValidateAudience = true,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,
              ValidIssuer = jwtOptions.Issuer,
              ValidAudience = jwtOptions.Audience,
              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey))
          };
      });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

                // Configuración para agregar soporte para JWT en Swagger UI
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Bearer {token}",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securityScheme);

                var securityRequirement = new OpenApiSecurityRequirement
    {
        { securityScheme, new[] { "Bearer" } }
    };

                c.AddSecurityRequirement(securityRequirement);
            });
            services.AddScoped<IMapperEmployee, MapperEmployee>();
        }
    }
}
