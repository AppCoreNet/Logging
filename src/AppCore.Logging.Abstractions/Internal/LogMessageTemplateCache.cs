using System;
using System.Collections.Concurrent;

namespace AppCore.Logging
{
    internal class LogMessageTemplateCache
    {
        public static LogMessageTemplateCache Instance { get; } = new LogMessageTemplateCache();

        private readonly ConcurrentDictionary<string, LogMessageTemplate> _templates =
            new ConcurrentDictionary<string, LogMessageTemplate>(StringComparer.Ordinal);

        public LogMessageTemplate Get(string format)
        {
            if (format == null)
                format = String.Empty;

            return _templates.GetOrAdd(format, t => new LogMessageTemplate(format));
        }
    }
}
