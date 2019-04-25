// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using Serilog;
using Serilog.Core;

namespace AppCore.Logging.Serilog
{
    /// <summary>
    /// Provides implementation of <see cref="ILoggerProvider"/> which creates <see cref="ILogger"/> instances
    /// which use Serilog.
    /// </summary>
    public class SerilogLoggerProvider : ILoggerProvider
    {
        private readonly global::Serilog.ILogger _logger;
        private readonly Action _dispose;

        /// <summary>
        /// Initializes a new instance of the <see cref="SerilogLoggerProvider"/> class.
        /// </summary>
        /// <remarks>
        /// If <paramref name="logger"/> is <c>null</c>, the static <see cref="Log.Logger"/> is used.
        /// </remarks>
        /// <param name="logger">The <see cref="T:global::Serilog.ILogger"/> used.</param>
        /// <param name="dispose">Whether to dispose the logger.</param>
        public SerilogLoggerProvider(global::Serilog.ILogger logger, bool dispose = false)
        {
            if (logger == null)
            {
                _logger = Log.Logger;
                _dispose = dispose ? new Action(Log.CloseAndFlush)
                    : null;
            }
            else
            {
                _logger = logger;
                _dispose = dispose && logger is IDisposable
                    ? new Action(() => ((IDisposable) _logger).Dispose())
                    : null;
            }
        }

        /// <inheritdoc />
        public ILogger CreateLogger(string category)
        {
            return new SerilogLogger(_logger.ForContext(Constants.SourceContextPropertyName, category));
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _dispose?.Invoke();
        }
    }
}
