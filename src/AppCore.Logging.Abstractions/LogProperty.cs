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
        public static ILogProperty Create<T>(string name, T value)
        {
            return new LogProperty<T>(name, value);
        }
    }

    /// <summary>
    /// Represents a property of a log event.
    /// </summary>
    /// <typeparam name="T">The type of the property value.</typeparam>
    /// <seealso cref="ILogProperty"/>
    public readonly struct LogProperty<T> : ILogProperty, IEquatable<LogProperty<T>>
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

        public override bool Equals(object obj)
        {
            return obj is LogProperty<T> property && Equals(property);
        }

        public bool Equals(LogProperty<T> other)
        {
            return Name == other.Name &&
                   EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        public override int GetHashCode()
        {
            int hashCode = -244751520;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(Value);
            return hashCode;
        }

        public static bool operator ==(LogProperty<T> property1, LogProperty<T> property2)
        {
            return property1.Equals(property2);
        }

        public static bool operator !=(LogProperty<T> property1, LogProperty<T> property2)
        {
            return !(property1 == property2);
        }
    }
}