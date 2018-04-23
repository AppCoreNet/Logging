using System;

namespace AppCore.Logging
{
    /// <summary>
    /// Represents a provider for <see cref="ILogger"/> instances.
    /// </summary>
    /// <remarks>
    /// An implementation of <see cref="ILoggerProvider"/> provides the actual implementation of a
    /// <see cref="ILogger"/> for a specific logging system.
    /// </remarks>
    public interface ILoggerProvider : IDisposable
    {
        /// <summary>
        /// Creates a new <see cref="ILogger"/> instance.
        /// </summary>
        /// <param name="category">The category name for events written by the logger.</param>
        /// <returns>The <see cref="ILogger"/> instance.</returns>
        ILogger CreateLogger(string category);
    }
}