using System;

namespace AppCore.Logging
{
    /// <summary>
    /// Represents a type used to create instances of <see cref="ILogger"/> from the registered <see cref="ILoggerProvider"/>s.
    /// </summary>
    /// <seealso cref="ILogger"/>
    /// <seealso cref="ILogger{TCategory}"/>
    /// <seealso cref="ILoggerProvider"/>
    public interface ILoggerFactory : IDisposable
    {
        /// <summary>
        /// Creates a new <see cref="ILogger"/> instance.
        /// </summary>
        /// <param name="category">The category name for events written by the logger.</param>
        /// <returns>The <see cref="ILogger"/> instance.</returns>
        ILogger CreateLogger(string category);
    }
}