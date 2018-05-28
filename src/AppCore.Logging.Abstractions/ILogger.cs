// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

namespace AppCore.Logging
{
    /// <summary>
    /// Represents a type used to write log events.
    /// </summary>
    /// <seealso cref="ILogger{TCategory}"/>
    /// <seealso cref="ILoggerFactory"/>
    public interface ILogger
    {
        /// <summary>
        /// Gets a value indicating whether logging of event with specified level is enabled.
        /// </summary>
        /// <param name="level">The <see cref="LogLevel"/> to test.</param>
        /// <returns><c>true</c> if logging is enabled; <c>false</c> otherwise.</returns>
        bool IsEnabled(LogLevel level);

        /// <summary>
        /// Logs a event.
        /// </summary>
        /// <param name="event">The <see cref="LogEvent"/> to log.</param>
        void Log(LogEvent @event);
    }

    /// <summary>
    /// Represents a generic type used to write log events where the category name is derived from
    /// the specified <typeparamref name="TCategory"/> type name.
    /// </summary>
    /// <typeparam name="TCategory">The type who's name is used for the logger category name.</typeparam>
    /// <seealso cref="ILogger"/>
    /// <seealso cref="ILoggerFactory"/>
    // ReSharper disable once UnusedTypeParameter
    public interface ILogger<TCategory> : ILogger
    {
    }
}