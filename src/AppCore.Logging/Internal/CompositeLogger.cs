// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System.Collections.Generic;
using System.Linq;

namespace AppCore.Logging
{
    internal class CompositeLogger : ILogger
    {
        private readonly ILogger[] _loggers;

        public CompositeLogger(IEnumerable<ILogger> loggers)
        {
            _loggers = loggers.ToArray();
        }

        public bool IsEnabled(LogLevel level)
        {
            for (int i = 0; i < _loggers.Length; i++)
            {
                if (_loggers[i].IsEnabled(level))
                    return true;
            }

            return false;
        }

        public void Log(LogEvent @event)
        {
            for (int i = 0; i < _loggers.Length; i++)
            {
                _loggers[i].Log(@event);
            }
        }
    }
}