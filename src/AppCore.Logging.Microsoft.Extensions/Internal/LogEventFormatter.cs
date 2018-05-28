// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using System.Globalization;
using System.Text;

namespace AppCore.Logging
{
    internal static class LogEventFormatter
    {
        public static string Format(LogEvent @event, Exception exception)
        {
            string message = @event.MessageTemplate.Render(@event.Properties, CultureInfo.InvariantCulture);

            if (exception == null)
            {
                return message;
            }

            var messageBuilder = new StringBuilder(message);
            messageBuilder.AppendLine();
            messageBuilder.Append(exception);
            return messageBuilder.ToString();
        }
    }
}