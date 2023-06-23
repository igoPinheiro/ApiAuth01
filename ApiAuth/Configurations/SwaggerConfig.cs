using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace ApiAuth.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Autenticação Prática",
                    Version = "v1",
                    Description = "API Prática Autenticação JWT",
                    Contact = new OpenApiContact
                    {
                        Name = "Igo Pinheiro",
                        Email = "igo.pinheiro1@gmail.com",
                        Url = new Uri("https://github.com/igoPinheiro")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "OSD",
                        Url = new Uri("https://github.com/igoPinheiro/ApiAuth01")
                    },
                    TermsOfService = new Uri("https://github.com/igoPinheiro/ApiAuth01")

                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                                    "JWT Authorization Header - utilizado com Bearer Authentication.\r\n\r\n" +
                                    "Digite 'Bearer' [espaço] e então seu token no campo abaixo.\r\n\r\n" +
                                    "Exemplo (informar sem as aspas): 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    BearerFormat = "JWT",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
