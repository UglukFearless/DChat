using Host.Configs;
using WebApi.Controllers;

namespace Host;

public class Startup
{
    private readonly IConfigurationRoot _configuration;

    /// <summary>
    /// Initializes a new instance of the <see cref="Startup"/> class with configuration provided.
    /// </summary>
    /// <param name="configuration">The <see cref="IConfigurationRoot"/>.</param>
    public Startup(IConfigurationRoot configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Configures application services.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/>.</param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSignalR();

        // Controllers
        var webApiAssembly = typeof(InfoController).Assembly;

        services.AddControllers().AddApplicationPart(webApiAssembly);
        services.AddEndpointsApiExplorer();
        services.AddSwaggerConfig();

    }

    /// <summary>
    /// Configures the HTTP request pipeline.
    /// </summary>
    /// <param name="app">The <see cref="IApplicationBuilder"/>.</param>
    /// <param name="env">The <see cref="IWebHostEnvironment"/>.</param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors();
        app.UseAuthorization();
        app.UseAuthorization();
        app.UseEndpoints(e => e.MapControllers());
    }
}
