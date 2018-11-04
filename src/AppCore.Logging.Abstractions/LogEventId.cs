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

        /// <summary>
        /// Converts <see cref="int"/> based id to <see cref="LogEventId"/>.
        /// </summary>
        /// <param name="id">The id of the event.</param>
        public static implicit operator LogEventId(int id)
        {
            return new LogEventId(id, null);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return String.IsNullOrEmpty(Name)
                ? Id.ToString(CultureInfo.InvariantCulture)
                : $"{Name}({Id})";
        }

        /// <inheritdoc />
        public bool Equals(LogEventId other)
        {
            return Id == other.Id && string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is LogEventId && Equals((LogEventId) obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                return (Id * 397) ^ (Name != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(Name) : 0);
            }
        }

        /// <summary>
        /// Compares two instances of <see cref="LogEventId"/> for equality.
        /// </summary>
        /// <param name="left">The first <see cref="LogEventId"/>.</param>
        /// <param name="right">The second <see cref="LogEventId"/>.</param>
        /// <returns><c>true</c> if both instances are equal; <c>false</c> otherwise.</returns>
        public static bool operator ==(LogEventId left, LogEventId right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two instances of <see cref="LogEventId"/> for inequality.
        /// </summary>
        /// <param name="left">The first <see cref="LogEventId"/>.</param>
        /// <param name="right">The second <see cref="LogEventId"/>.</param>
        /// <returns><c>true</c> if the two instances are not equal; <c>false</c> otherwise.</returns>
        public static bool operator !=(LogEventId left, LogEventId right)
        {
            return !left.Equals(right);
        }
    }
}