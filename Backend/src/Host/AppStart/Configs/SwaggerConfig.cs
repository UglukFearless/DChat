using Microsoft.OpenApi.Models;

namespace Host.Configs;

/// <summary>
/// Swagger configuration
/// </summary>
public static class SwaggerConfig
{
    /// <summary>
    /// Adds a configuration for Swagger
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/>.</param>
    public static void AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddSwaggerGen(config =>
        {
            config.AddSecurityDefinition("Apikey", new OpenApiSecurityScheme
            {
                Description = "Api key needed to access the endpoints. X-Api-Key: My_API_Key",
                In = ParameterLocation.Header,
                Name = "X-Api-Key",
                Type = SecuritySchemeType.ApiKey
            });

            config.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Name = "X-Api-Key",
                        Type = SecuritySchemeType.ApiKey,
                        In = ParameterLocation.Header,
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "ApiKey"
                        },
                    },
                    new string[] {}
                }
            });

        });
    }
}
