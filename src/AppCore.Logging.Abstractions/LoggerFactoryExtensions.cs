using System;
using AppCore.Diagnostics;

namespace AppCore.Logging
{
    /// <summary>
    /// Provides extension methods for the <see cref="ILoggerFactory"/>.
    /// </summary>
    public static class LoggerFactoryExtensions
    {
        /// <summary>
        /// Creates a <see cref="ILogger"/> where the category name is derived from
        /// the specified <typeparamref name="TCategory"/> type name.
        /// </summary>
        /// <typeparam name="TCategory">The type who's name is used for the logger category name.</typeparam>
        /// <returns>The <seealso cref="ILogger"/> instance.</returns>
        /// <exception cref="ArgumentNullException">Argument <paramref name="factory"/> is <c>null</c>.</exception>
        public static ILogger CreateLogger<TCategory>(this ILoggerFactory factory)
        {
            Ensure.Arg.NotNull(factory, nameof(factory));
            return factory.CreateLogger(typeof(TCategory).FullName);
        }
    }
}