// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using AppCore.Diagnostics;

namespace AppCore.Logging
{
    /// <summary>
    /// Provides an implementation of the <see cref="ILoggerFactory"/> interface.
    /// </summary>
    public class LoggerFactory : ILoggerFactory
    {
        private readonly IEnumerable<ILoggerProvider> _providers;

        private readonly ConcurrentDictionary<string, ILogger> _loggers =
            new ConcurrentDictionary<string, ILogger>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerFactory"/> class.
        /// </summary>
        /// <param name="providers">The <see cref="ILoggerProvider"/>s used to create instances of <see cref="ILogger"/>.</param>
        /// <exception cref="ArgumentNullException">Argument <paramref name="providers"/> is <c>null</c>.</exception>
        public LoggerFactory(IEnumerable<ILoggerProvider> providers)
        {
            Ensure.Arg.NotNull(providers, nameof(providers));
            _providers = providers;
        }

        /// <inheritdoc />
        public ILogger CreateLogger(string category)
        {
            return _loggers.GetOrAdd(category, CreateCompositeLogger);

            CompositeLogger CreateCompositeLogger(string c)
            {
                ILogger[] loggers = _providers.Select(p => p.CreateLogger(c)).ToArray();
                return new CompositeLogger(loggers);
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
        }
    }
}