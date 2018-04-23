using AppCore.Logging;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    public class LoggingFacility : Facility, ILoggingFacility
    {
        public LoggingFacility()
            : base(
                r => r.TryAddSingleton<ILoggerFactory, LoggerFactory>()
                      .TryAddTransient(typeof(ILogger<>), typeof(Logger<>)))
        {
        }
    }
}
