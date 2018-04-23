using Microsoft.Extensions.Logging;

namespace AppCore.Logging
{
    internal static class LogEventExtensions
    {
        public static global::Microsoft.Extensions.Logging.LogLevel ToMicrosoftLogLevel(this LogLevel level)
        {
            return (global::Microsoft.Extensions.Logging.LogLevel)level;
        }

        public static EventId ToMicrosoftEventId(this LogEventId eventId)
        {
            return new EventId(eventId.Id, eventId.Name);
        }
    }
}