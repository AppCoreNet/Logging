// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System.Collections.Generic;
using System.Linq;

namespace AppCore.Logging
{
    internal class CompositeLogger : ILogger
    {
        private readonly IEnumerable<ILogger> _loggers;

        public CompositeLogger(IEnumerable<ILogger> loggers)
        {
            _loggers = loggers;
        }

        public bool IsEnabled(LogLevel level)
        {
            return _loggers.Any(l => l.IsEnabled(level));
        }

        public void Log(LogEvent @event)
        {
            foreach (ILogger logger in _loggers)
            {
                logger.Log(@event);
            }
        }
    }
}