// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using AppCore.Diagnostics;

namespace AppCore.Logging
{
    /// <summary>
    /// Provides an implementation of the <see cref="ILogger{TCategory}"/> interface.
    /// </summary>
    /// <typeparam name="TCategory">The type who's name is used for the logger category name.</typeparam>
    public class Logger<TCategory> : ILogger<TCategory>
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger{TCategory}"/> class.
        /// </summary>
        /// <param name="factory">The <see cref="ILoggerFactory"/> used to create an instance of <see cref="ILogger"/>.</param>
        /// <exception cref="ArgumentNullException">Argument <paramref name="factory"/> is <c>null</c>.</exception>
        public Logger(ILoggerFactory factory)
        {
            Ensure.Arg.NotNull(factory, nameof(factory));
            _logger = factory.CreateLogger<TCategory>();
        }

        /// <inheritdoc />
        public bool IsEnabled(LogLevel level)
        {
            return _logger.IsEnabled(level);
        }

        /// <inheritdoc />
        public void Log(LogEvent @event)
        {
            _logger.Log(@event);
        }
    }
}