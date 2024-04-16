namespace Smart.Admin.Template.RestApi.Infrastructure.CrossCutting;

using ToolBox.Framework.Logging;

public sealed class LogWrapper : ILog
{
    private readonly ILog log;

    public LogWrapper(ILog log)
    {
        this.log = log;
    }

    public void Info(string message)
    {
        this.log.Info(message);
    }

    public void Info(string message, Func<object> dataFunc)
    {
        this.log.Info(message, GetLogData(dataFunc));
    }

    public void Warning(string message)
    {
        this.log.Warning(message);
    }

    public void Warning(string message, Exception exception)
    {
        this.log.Warning(message, exception);
    }

    public void Warning(string message, Func<object> dataFunc)
    {
        this.log.Warning(message, GetLogData(dataFunc));
    }

    public void Warning(string message, Exception exception, Func<object> dataFunc)
    {
        this.log.Warning(message, exception, GetLogData(dataFunc));
    }

    public void Error(string message)
    {
        this.log.Error(message);
    }

    public void Error(string message, Exception exception)
    {
        this.log.Error(message, exception);

        // TODO ADD EXTERNAL LOG
    }

    public void Error(string message, Exception exception, Func<object> dataFunc)
    {
        this.log.Error(message, exception, GetLogData(dataFunc));

        // TODO ADD EXTERNAL LOG
    }

    public void Fatal(string message)
    {
        this.log.Fatal(message);
    }

    public void Fatal(string message, Exception exception)
    {
        this.log.Fatal(message, exception);
    }

    public void Fatal(string message, Func<object> dataFunc)
    {
        this.log.Fatal(message, null, GetLogData(dataFunc));
    }

    public void Fatal(string message, Exception exception, Func<object> dataFunc)
    {
        this.log.Fatal(message, exception, GetLogData(dataFunc));
    }

    public void Verbose(string message)
    {
        this.log.Verbose(message);
    }

    public void Verbose(string message, Func<object> dataFunc)
    {
        this.log.Verbose(message, GetLogData(dataFunc));
    }

    public bool IsEnabled(LogLevel loglevel)
    {
        return ToolBox.Framework.Logging.Log.Current.IsEnabled(loglevel);
    }

    public void Log(LogLevel logLevel, string message)
    {
        this.log.Log(logLevel, message);
    }

    public void Log(LogLevel logLevel, string message, Func<object> dataFunc)
    {
        this.log.Log(logLevel, message, dataFunc);
    }

    public void Log(LogLevel logLevel, string message, Exception exception, Func<object> dataFunc)
    {
        this.log.Log(logLevel, message, exception, dataFunc);
    }

    public LogLevel MinimumLevel { get; }

    private static Func<object> GetLogData(Func<object> dataFunc)
    {
        return () => new
        {
            InfoData = dataFunc(),
        };
    }
}