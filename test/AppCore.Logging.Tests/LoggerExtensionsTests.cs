// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using Xunit;

namespace AppCore.Logging
{
    public class LoggerExtensionsTests
    {
        private static readonly DateTimeOffset Timestamp = new DateTimeOffset(2000, 9, 11, 13, 10, 23, 42, TimeSpan.Zero);
        private static readonly LogEventId EventId = new LogEventId(new Random().Next(), Guid.NewGuid().ToString("N"));
        private static readonly Exception EventException = new Exception();
        private readonly ILogger _logger;

        public LoggerExtensionsTests()
        {
            LoggerExtensions.GetTimestamp = () => Timestamp;
            _logger = Substitute.For<ILogger>();
            _logger.IsEnabled(Arg.Any<LogLevel>()).Returns(true);
        }

        private class LogArgsTestDataGenerator : IEnumerable<object[]>
        {
            private readonly IList<object[]> _properties = new List<object[]>()
            {
                new object[]
                {
                    "message",
                    new object[0],
                    new LogProperty[0]
                },
                new object[]
                {
                    "message {value1}",
                    new object[] {1},
                    new[] {new LogProperty("value1", (object)1)}
                },
                new object[]
                {
                    "message {value1} {value2}",
                    new object[]
                    {
                        "abc",
                        true
                    },
                    new[]
                    {
                        new LogProperty("value1", (object)"abc"),
                        new LogProperty("value2", (object)true)
                    }
                }
            };

            public IEnumerator<object[]> GetEnumerator()
            {
                return _properties.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        private void Log_With_Args_Logs_Event(
            Action<ILogger, LogEventId, Exception, string, object[]> logMethod,
            LogLevel level,
            LogEventId eventId,
            Exception exception,
            string format,
            object[] args,
            LogProperty[] expectedProperties)
        {
            logMethod(_logger, eventId, exception, format, args);

            _logger.Received()
                  .Log(
                      Arg.Is<LogEvent>(
                          @event =>
                              @event.Timestamp == Timestamp
                              && @event.Level == level
                              && @event.Id == eventId
                              && @event.Exception == exception
                              && @event.MessageTemplate.Format == format
                              && @event.Properties.SequenceEqual(expectedProperties, EqualityComparer<LogProperty>.Default)
                      ));
        }

        private void Log_With_Args_Logs_Event_WithoutException(
            Action<ILogger, LogEventId, string, object[]> logMethod,
            LogLevel level,
            LogEventId eventId,
            string format,
            object[] args,
            LogProperty[] expectedProperties)
        {
            Log_With_Args_Logs_Event(
                (logger1, eventId1, exception, format1, args1) => logMethod(logger1, eventId1, format1, args1),
                level,
                eventId,
                null,
                format,
                args,
                expectedProperties);
        }

        [Theory]
        [ClassData(typeof(LogArgsTestDataGenerator))]
        public void LogTrace_With_Args_Logs_Trace_Event(string format, object[] args, LogProperty[] expectedProperties)
        {
            Log_With_Args_Logs_Event(LoggerExtensions.LogTrace, LogLevel.Trace, EventId, EventException, format, args, expectedProperties);
        }

        [Theory]
        [ClassData(typeof(LogArgsTestDataGenerator))]
        public void LogTrace_With_Args_Logs_Trace_Event_WithoutException(string format, object[] args, LogProperty[] expectedProperties)
        {
            Log_With_Args_Logs_Event_WithoutException(LoggerExtensions.LogTrace, LogLevel.Trace, EventId, format, args, expectedProperties);
        }

        [Theory]
        [ClassData(typeof(LogArgsTestDataGenerator))]
        public void LogDebug_With_Args_Logs_Debug_Event(string format, object[] args, LogProperty[] expectedProperties)
        {
            Log_With_Args_Logs_Event(LoggerExtensions.LogDebug, LogLevel.Debug, EventId, EventException, format, args, expectedProperties);
        }

        [Theory]
        [ClassData(typeof(LogArgsTestDataGenerator))]
        public void LogDebug_With_Args_Logs_Debug_Event_WithoutException(string format, object[] args, LogProperty[] expectedProperties)
        {
            Log_With_Args_Logs_Event_WithoutException(LoggerExtensions.LogDebug, LogLevel.Debug, EventId, format, args, expectedProperties);
        }

        [Theory]
        [ClassData(typeof(LogArgsTestDataGenerator))]
        public void LogInfo_With_Args_Logs_Info_Event(string format, object[] args, LogProperty[] expectedProperties)
        {
            Log_With_Args_Logs_Event(LoggerExtensions.LogInfo, LogLevel.Info, EventId, EventException, format, args, expectedProperties);
        }

        [Theory]
        [ClassData(typeof(LogArgsTestDataGenerator))]
        public void LogInfo_With_Args_Logs_Info_Event_WithoutException(string format, object[] args, LogProperty[] expectedProperties)
        {
            Log_With_Args_Logs_Event_WithoutException(LoggerExtensions.LogInfo, LogLevel.Info, EventId, format, args, expectedProperties);
        }

        [Theory]
        [ClassData(typeof(LogArgsTestDataGenerator))]
        public void LogWarning_With_Args_Logs_Warning_Event(string format, object[] args, LogProperty[] expectedProperties)
        {
            Log_With_Args_Logs_Event(LoggerExtensions.LogWarning, LogLevel.Warning, EventId, EventException, format, args, expectedProperties);
        }

        [Theory]
        [ClassData(typeof(LogArgsTestDataGenerator))]
        public void LogWarning_With_Args_Logs_Warning_Event_WithoutException(string format, object[] args, LogProperty[] expectedProperties)
        {
            Log_With_Args_Logs_Event_WithoutException(LoggerExtensions.LogWarning, LogLevel.Warning, EventId, format, args, expectedProperties);
        }

        [Theory]
        [ClassData(typeof(LogArgsTestDataGenerator))]
        public void LogError_With_Args_Logs_Error_Event(string format, object[] args, LogProperty[] expectedProperties)
        {
            Log_With_Args_Logs_Event(LoggerExtensions.LogError, LogLevel.Error, EventId, EventException, format, args, expectedProperties);
        }

        [Theory]
        [ClassData(typeof(LogArgsTestDataGenerator))]
        public void LogError_With_Args_Logs_Error_Event_WithoutException(string format, object[] args, LogProperty[] expectedProperties)
        {
            Log_With_Args_Logs_Event_WithoutException(LoggerExtensions.LogError, LogLevel.Error, EventId, format, args, expectedProperties);
        }

        [Theory]
        [ClassData(typeof(LogArgsTestDataGenerator))]
        public void LogCritical_With_Args_Logs_Critical_Event(string format, object[] args, LogProperty[] expectedProperties)
        {
            Log_With_Args_Logs_Event(LoggerExtensions.LogCritical, LogLevel.Critical, EventId, EventException, format, args, expectedProperties);
        }

        [Theory]
        [ClassData(typeof(LogArgsTestDataGenerator))]
        public void LogCritical_With_Args_Logs_Critical_Event_WithoutException(string format, object[] args, LogProperty[] expectedProperties)
        {
            Log_With_Args_Logs_Event_WithoutException(LoggerExtensions.LogCritical, LogLevel.Critical, EventId, format, args, expectedProperties);
        }
    }
}
