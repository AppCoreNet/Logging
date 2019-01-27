// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System.Collections.Generic;
using Serilog.Events;

namespace AppCore.Logging.Serilog
{
    internal static class LogEventExtensions
    {
        public static LogEventLevel ToSerilogLogLevel(this LogLevel level)
        {
            return (LogEventLevel) level;
        }

        public static IEnumerable<LogEventProperty> GetSerilogProperties(this LogEvent @event, global::Serilog.ILogger logger)
        {
            foreach (ILogProperty property in @event.Properties)
            {
                logger.BindProperty(property.Name, property.Value, true, out LogEventProperty logEventProperty);
                yield return logEventProperty;
            }

            yield return new LogEventProperty(SerilogPropertyNames.EventId, new ScalarValue(@event.Id));
        }
    }
}
