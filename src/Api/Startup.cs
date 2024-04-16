namespace Smart.Admin.Template.RestApi.Api;

using Infrastructure.CrossCutting.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Modules;

public sealed class Startup(IConfiguration configuration, IWebHostEnvironment env) : IStartup
{
    public IConfiguration Configuration { get; } = configuration;
    public IWebHostEnvironment Env { get; } = env;

    public void ConfigureServices(IServiceCollection service)
    {
        var applicationSettings = this.Configuration.Get<ApplicationSettings>();

        service.Configure<ApplicationSettings>(this.Configuration);
        service.TryAddSingleton(applicationSettings);
        
        
        service
            .AddLogging(applicationSettings.Logging)
            .AddPolly()
            .AddWebFramework()
            .AddVersioning()
            .AddCors()
            .AddSwagger(applicationSettings.Swagger)
            .AddHttpClient()
            .AddConverters()
            .AddMongoDb(applicationSettings.Mongo)
            .AddGateways()
            .AddApplicationServices();

    }

    public void Configure(WebApplication app, IHostApplicationLifetime lifetime)
    {
        app
            .UseRouting()
            .UseEndpoints(endpoints =>
                endpoints.MapControllers());
    }
}

public interface IStartup
{
    IConfiguration Configuration { get; }

    IWebHostEnvironment Env { get; }

    void ConfigureServices(IServiceCollection service);

    void Configure(WebApplication app, IHostApplicationLifetime lifetime);
}

public static class StartupExtensions
{
    public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder webApplicationBuilder)
        where TStartup : IStartup
    {
        webApplicationBuilder.WebHost.ConfigureAppConfiguration(AppConfiguration);

        if (Activator.CreateInstance(typeof(TStartup), webApplicationBuilder.Configuration,
                webApplicationBuilder.Environment) is not IStartup
            startup) throw new ArgumentException("Class Startup.cs Invalid!");

        startup.ConfigureServices(webApplicationBuilder.Services);

        var app = webApplicationBuilder.Build();

        startup.Configure(app, app.Services.GetRequiredService<IHostApplicationLifetime>());

        app.Run();

        return webApplicationBuilder;
    }

    private static void AppConfiguration(WebHostBuilderContext context, IConfigurationBuilder config)
    {
        var basePath = Directory.GetCurrentDirectory();

        config
            .SetBasePath(basePath)
            .AddJsonFile("conf/appsettings.json", false, true)
            .AddEnvironmentVariables();
    }
}