// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NSubstitute;
using Xunit;

namespace AppCore.Logging
{
    public class LoggerEventTests
    {
        private static readonly DateTimeOffset _timestamp = new DateTimeOffset(2000, 9, 11, 13, 10, 23, 42, TimeSpan.Zero);
        private static readonly LogEventId _eventId = new LogEventId(new Random().Next(), Guid.NewGuid().ToString("N"));
        private static readonly Exception _eventException = new Exception();
        private readonly ILogger _logger;

        public LoggerEventTests()
        {
            LoggerExtensions.GetTimestamp = () => _timestamp;
            _logger = Substitute.For<ILogger>();
            _logger.IsEnabled(Arg.Any<LogLevel>()).Returns(true);
        }

        [Fact]
        public void Define_Throws_If_ParameterCount_DoesNotMatch_VariableCount()
        {
            Assert.Throws<ArgumentException>(() => LoggerEvent.Define<int>(LogLevel.Critical, default, "abc"));
        }

        [Theory]
        [InlineData(LogLevel.Trace, "message")]
        [InlineData(LogLevel.Info, "message {extra1}")]
        [InlineData(LogLevel.Trace, "message {value1}", 1)]
        [InlineData(LogLevel.Info, "message {value1}", 1)]
        [InlineData(LogLevel.Trace, "message {value1} {value2}", 1, "2")]
        [InlineData(LogLevel.Info, "message {value1} {value2}", 1, "2")]
        [InlineData(LogLevel.Trace, "message {value1} {value2} {value3}", 1, "2", true)]
        [InlineData(LogLevel.Info, "message {value1} {value2} {value3}", 1, "2", true)]
        [InlineData(LogLevel.Trace, "message {value1} {value2} {value3} {value4}", 1, "2", true, 1234.0)]
        [InlineData(LogLevel.Info, "message {value1} {value2} {value3} {value4}", 1, "2", true, 1234.0)]
        [InlineData(LogLevel.Trace, "message {value1} {value2} {value3} {value4} {value5}", 1, "2", true, 1234.0, 'c')]
        [InlineData(LogLevel.Info, "message {value1} {value2} {value3} {value4} {value5}", 1, "2", true, 1234.0, 'c')]
        public void Define_CreatesDelegate_Which_WritesEvent(LogLevel level, string format, params object[] args)
        {
            LogProperty[] extraProperties = {new LogProperty("extra1", 1234), new LogProperty("extra2", 4321)};

            IEnumerable<LogProperty> expectedProperties = new LogProperty[]
            {
                new LogProperty("value1", 1),
                new LogProperty("value2", "2"),
                new LogProperty("value3", true),
                new LogProperty("value4", 1234.0),
                new LogProperty("value5", 'c')
            };

            expectedProperties = expectedProperties.Take(args.Length);
            expectedProperties = expectedProperties.Concat(extraProperties);

            if (args.Length == 0)
            {
                LoggerEventDelegate loggerDelegate = LoggerEvent.Define(level, _eventId, format);
                loggerDelegate(_logger, _eventException, extraProperties);
            }
            else
            {
                MethodInfo method = typeof(LoggerEvent)
                                    .GetMembers()
                                    .OfType<MethodInfo>()
                                    .Single(
                                        m => m.Name == "Define"
                                             && m.GetGenericArguments()
                                                 .Length
                                             == args.Length);

                method = method.MakeGenericMethod(args.Select(a => a.GetType()).ToArray());

                var loggerDelegate = (Delegate) method.Invoke(null, new object[] {level, _eventId, format});

                var loggerDelegateArgs = new object [args.Length + 3];
                loggerDelegateArgs[0] = _logger;
                Array.Copy(args, 0, loggerDelegateArgs, 1, args.Length);
                loggerDelegateArgs[args.Length + 1] = _eventException;
                loggerDelegateArgs[args.Length + 2] = extraProperties;

                loggerDelegate.DynamicInvoke(loggerDelegateArgs);
            }

            _logger.Received().Log(Arg.Is<LogEvent>(
                @event =>
                    @event.Timestamp == _timestamp
                    && @event.Level == level
                    && @event.Id == _eventId
                    && @event.Exception == _eventException
                    && @event.MessageTemplate.Format == format
                    && @event.Properties.SequenceEqual(expectedProperties)));
        }
    }
}
