// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;

namespace AppCore.Logging
{
    /// <summary>
    /// Represents a property of a log event.
    /// </summary>
    public readonly struct LogProperty
    {
        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the value of the property.
        /// </summary>
        public object Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogProperty"/> struct.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="value">The value of the property.</param>
        /// <exception cref="ArgumentNullException">Argument <paramref name="name"/> is <c>null</c>.</exception>
        public LogProperty(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}