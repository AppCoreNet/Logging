// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using DotNet.Extensions.Logging.Testing;
using NSubstitute;
using Xunit;
using MicrosoftLogEvent = DotNet.Extensions.Logging.Testing.LogEvent;
using MicrosoftLogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace AppCore.Logging
{
    public class MicrosoftLoggerTests
    {
        private readonly ILogger _logger;
        private readonly IObserver<MicrosoftLogEvent> _logObserver;
        private readonly ObservableLogger _observableLogger;

        public MicrosoftLoggerTests()
        {
            _logObserver = Substitute.For<IObserver<MicrosoftLogEvent>>();
            _observableLogger = new ObservableLogger("logger", (s, level) => true, _logObserver);
            _observableLogger.BeginScope<string>("scope");
            _logger = new MicrosoftLogger(_observableLogger);
        }

        [Fact]
        public void Log_Writes_MicrosoftEvent()
        {
            var logEventId = new LogEventId(new Random().Next(), "eventName");

            var logEvent = new LogEvent(
                DateTimeOffset.Now,
                LogLevel.Trace,
                logEventId,
                new LogMessageTemplate("message"),
                new[] { LogProperty.Create("value1", 1)},
                new Exception());

            _logger.Log(logEvent);

            _logObserver.Received()
                .OnNext(Arg.Is<MicrosoftLogEvent>(
                    loggedEvent =>
                        loggedEvent.Message == LogEventFormatter.Format(logEvent, logEvent.Exception)
                        && loggedEvent.Level == (MicrosoftLogLevel) logEvent.Level
                        && loggedEvent.Id.Id == logEventId.Id
                        && loggedEvent.Id.Name == logEventId.Name
                        && loggedEvent.Error == logEvent.Exception
                        && Equals((LogEvent)loggedEvent.State, logEvent)
                ));
        }
    }
}
