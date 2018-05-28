// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

namespace AppCore.Logging
{
    /// <summary>
    /// Represents a property which is added to a <see cref="LogEvent"/>.
    /// </summary>
    /// <seealso cref="LogProperty"/>
    /// <seealso cref="LogProperty{T}"/>
    public interface ILogProperty
    {
        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the vale of the property.
        /// </summary>
        object Value { get; }
    }
}