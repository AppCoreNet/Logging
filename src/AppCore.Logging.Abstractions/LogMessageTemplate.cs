// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using AppCore.Diagnostics;

namespace AppCore.Logging
{
    /// <summary>
    /// Provides log message template parsing and rendering.
    /// </summary>
    public class LogMessageTemplate
    {
        private static readonly Regex _variablesRegEx =
            new Regex("(?<!\\{)\\{([^}]+)\\}(?!\\})", RegexOptions.Compiled | RegexOptions.Multiline);

        //(?<!\{)\{([^}]+)\}(?!\})
        //{(.*?)}

        /// <summary>
        /// Gets the format of the log message.
        /// </summary>
        public string Format { get; }

        /// <summary>
        /// Gets the <see cref="IReadOnlyList{T}"/> of log message variable names.
        /// </summary>
        public IReadOnlyList<string> VariableNames { get; }

        internal static readonly LogMessageTemplate Empty = new LogMessageTemplate(String.Empty);

        /// <summary>
        /// Initializes a new instance of the <see cref="LogMessageTemplate"/> class.
        /// </summary>
        /// <param name="format">The format used to render the log message.</param>
        /// <exception cref="ArgumentNullException">Argument <paramref name="format"/> is <c>null</c>.</exception>
        public LogMessageTemplate(string format)
        {
            Ensure.Arg.NotNull(format, nameof(format));

            Format = format;
            VariableNames = ParseVariableNames(format);
        }

        private static IReadOnlyList<string> ParseVariableNames(string message)
        {
            MatchCollection matches = _variablesRegEx.Matches(message);
            var result = new List<string>(matches.Count);

            foreach (Match match in matches)
            {
                string variablePattern = match.Value;
                result.Add(variablePattern.Substring(1, variablePattern.Length - 2));
            }

            return result;
        }

        /// <summary>
        /// Renders the log message using the given properties.
        /// </summary>
        /// <param name="properties">The properties used when rendering the message.</param>
        /// <param name="culture">The culture used to format properties.</param>
        /// <returns>The rendered log message.</returns>
        /// <exception cref="ArgumentNullException">The argument <paramref name="properties"/> is <c>null</c>.</exception>
        public string Render(IEnumerable<ILogProperty> properties, CultureInfo culture)
        {
            Ensure.Arg.NotNull(properties, nameof(properties));

            culture = culture ?? CultureInfo.CurrentUICulture;

            Dictionary<string, object> propertiesDictionary =
                properties.ToDictionary(p => p.Name, p => p.Value);

            return _variablesRegEx.Replace(
                Format,
                m =>
                {
                    string variablePattern = m.Value;
                    string variableName = variablePattern.Substring(1, variablePattern.Length - 2);
                    return Convert.ToString(propertiesDictionary[variableName], culture);
                });
        }
    }
}