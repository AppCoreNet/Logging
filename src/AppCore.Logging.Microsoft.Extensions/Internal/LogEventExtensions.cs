// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AppCore.Logging.Microsoft.Extensions
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

        public static IEnumerable<KeyValuePair<string, object>> GetKeyValueProperties(this LogEvent @event)
        {
            IReadOnlyList<LogProperty> eventProperties = @event.Properties;
            var properties = new KeyValuePair<string, object>[eventProperties.Count + 1];
            for (int i = 0; i < eventProperties.Count; i++)
            {
                properties[i] = new KeyValuePair<string, object>(eventProperties[i].Name, eventProperties[i].Value);
            }

            properties[eventProperties.Count] = new KeyValuePair<string, object>("{OriginalFormat}", @event.MessageTemplate.Format);
            return properties;
        }
    }
}