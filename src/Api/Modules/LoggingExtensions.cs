namespace Smart.Admin.Template.RestApi.Api.Modules;

using Infrastructure.CrossCutting;
using Infrastructure.CrossCutting.Configuration;
using ToolBox.Framework.Logging;
using ToolBox.Framework.Logging.Renders.Default;
using ToolBox.Framework.Logging.Writers.Console;
using ToolBox.Framework.Logging.Writers.ElasticSearch;
using ToolBox.Framework.Logging.Writers.RollingFileBySize;

internal static class LoggingExtensions
{
    internal static IServiceCollection AddLogging(this IServiceCollection serviceCollection,
        string envEnvironmentName,
        LoggingSettings loggingSettings)
    {
        var log = new Logger(loggingSettings.LogLevel,
            new DefaultJsonLogDocumentRender(),
            new List<ILogWriter>()
            {
                new ConsoleWriter(),
                new RollingFileBySizeWriter(loggingSettings.Directory,loggingSettings.NameFile, loggingSettings.LogLevel > LogLevel.Info ? 104857600 : 536870912),
                new ElasticSearchWriter(loggingSettings.Elastic.Url,envEnvironmentName,loggingSettings.Elastic.LogPrefix),
            });

        var logWrapper = new LogWrapper(log);

        serviceCollection.AddSingleton<ILog>(logWrapper);

        Log.Current = logWrapper;

        return serviceCollection;
    }
}