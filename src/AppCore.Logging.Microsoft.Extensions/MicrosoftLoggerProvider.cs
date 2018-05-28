// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using AppCore.Diagnostics;
using MicrosoftLogging = Microsoft.Extensions.Logging;

namespace AppCore.Logging
{
    /// <summary>
    /// Provides implementation of <see cref="ILoggerProvider"/> which creates <see cref="ILogger"/> instances
    /// which use Microsoft.Extensions.Logging.
    /// </summary>
    public class MicrosoftLoggerProvider : ILoggerProvider
    {
        private readonly MicrosoftLogging.ILoggerFactory _factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="MicrosoftLoggerProvider"/> class.
        /// </summary>
        /// <param name="factory">
        ///     The <see cref="MicrosoftLogging.ILoggerFactory"/> used to create instances of <see cref="ILogger"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">Argument <paramref name="factory"/> is <c>null</c>.</exception>
        public MicrosoftLoggerProvider(MicrosoftLogging.ILoggerFactory factory)
        {
            Ensure.Arg.NotNull(factory, nameof(factory));
            _factory = factory;
        }

        /// <inheritdoc />
        public ILogger CreateLogger(string category)
        {
            return new MicrosoftLogger(_factory.CreateLogger(category));
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _factory.Dispose();
        }
    }
}