// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using System.Globalization;

namespace AppCore.Logging
{
    /// <summary>
    /// Represents a unique identifier for a log event.
    /// </summary>
    public readonly struct LogEventId : IEquatable<LogEventId>
    {
        /// <summary>
        /// Gets the unique identifier value.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the name of the unique identifier.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogEventId"/> struct.
        /// </summary>
        /// <param name="id">The unique identifier value.</param>
        /// <param name="name">The name of the unique identifier.</param>
        public LogEventId(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static implicit operator LogEventId(int id)
        {
            return new LogEventId(id, null);
        }

        public override string ToString()
        {
            return String.IsNullOrEmpty(Name)
                ? Id.ToString(CultureInfo.InvariantCulture)
                : $"{Name}({Id})";
        }

        public bool Equals(LogEventId other)
        {
            return Id == other.Id && string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is LogEventId && Equals((LogEventId) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id * 397) ^ (Name != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(Name) : 0);
            }
        }

        public static bool operator ==(LogEventId left, LogEventId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LogEventId left, LogEventId right)
        {
            return !left.Equals(right);
        }
    }
}