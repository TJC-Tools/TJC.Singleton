using Microsoft.Extensions.Logging;

namespace TJC.Singleton.Tests.Mocks.Logging;

internal class MockLogger : ILogger
{
    public static MockLogger Default => new();

    public IDisposable? BeginScope<TState>(TState state)
        where TState : notnull
        => default!;

    public bool IsEnabled(LogLevel logLevel) => true;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        Trace.WriteLine($"[{logLevel}:{eventId}] {formatter(state, exception)}");
    }
}
