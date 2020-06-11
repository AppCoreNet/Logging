// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
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
            yield return new KeyValuePair<string, object>("{OriginalFormat}", @event.MessageTemplate.Format);
            foreach (ILogProperty property in @event.Properties)
            {
                yield return new KeyValuePair<string, object>(String.Concat("{", property.Name, "}"), property.Value);
            }
        }
    }
}