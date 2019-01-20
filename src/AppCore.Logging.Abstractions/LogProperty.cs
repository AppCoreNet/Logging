// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using System.Collections.Generic;
using AppCore.Diagnostics;

namespace AppCore.Logging
{
    /// <summary>
    /// Helper for creating <see cref="ILogProperty"/> instances.
    /// </summary>
    public static class LogProperty
    {
        /// <summary>
        /// Creates a new instance of <see cref="LogProperty{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="name">The name of the property.</param>
        /// <param name="value">The value of the property.</param>
        /// <returns>A new instance of <see cref="LogProperty{T}"/>.</returns>
        public static LogProperty<T> Create<T>(string name, T value)
        {
            return new LogProperty<T>(name, value);
        }
    }

    /// <summary>
    /// Represents a property of a log event.
    /// </summary>
    /// <typeparam name="T">The type of the property value.</typeparam>
    /// <seealso cref="ILogProperty"/>
    public sealed class LogProperty<T> : ILogProperty, IEquatable<LogProperty<T>>
    {
        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the value of the property.
        /// </summary>
        public T Value { get; }

        object ILogProperty.Value => Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogProperty{T}"/> struct.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="value">The value of the property.</param>
        /// <exception cref="ArgumentNullException">Argument <paramref name="name"/> is <c>null</c>.</exception>
        public LogProperty(string name, T value)
        {
            Ensure.Arg.NotNull(name, nameof(name));

            Name = name;
            Value = value;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is LogProperty<T> property && Equals(property);
        }

        /// <inheritdoc />
        public bool Equals(LogProperty<T> other)
        {
            return !ReferenceEquals(other, null)
                   && Name == other.Name
                   && EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            int hashCode = -244751520;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(Value);
            return hashCode;
        }

        /// <summary>
        /// Compares two instances of <see cref="LogProperty{T}"/> for equality.
        /// </summary>
        /// <param name="left">The first <see cref="LogProperty{T}"/>.</param>
        /// <param name="right">The second <see cref="LogProperty{T}"/>.</param>
        /// <returns><c>true</c> if both instances are equal; <c>false</c> otherwise.</returns>
        public static bool operator ==(LogProperty<T> left, LogProperty<T> right)
        {
            return !ReferenceEquals(left, null) && left.Equals(right);
        }

        /// <summary>
        /// Compares two instances of <see cref="LogProperty{T}"/> for inequality.
        /// </summary>
        /// <param name="left">The first <see cref="LogProperty{T}"/>.</param>
        /// <param name="right">The second <see cref="LogProperty{T}"/>.</param>
        /// <returns><c>true</c> if the two instances are not equal; <c>false</c> otherwise.</returns>
        public static bool operator !=(LogProperty<T> left, LogProperty<T> right)
        {
            return !(left == right);
        }
    }
}