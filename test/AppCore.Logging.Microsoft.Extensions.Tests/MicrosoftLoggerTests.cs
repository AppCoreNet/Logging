// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using System.Collections.Generic;
using DotNet.Extensions.Logging.Testing;
using FluentAssertions;
using NSubstitute;
using Xunit;
using MicrosoftLogEvent = DotNet.Extensions.Logging.Testing.LogEvent;
using MicrosoftLogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace AppCore.Logging.Microsoft.Extensions
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
                new LogMessageTemplate("message {value1}"),
                new[] { new LogProperty("value1", 1) },
                new Exception());

            MicrosoftLogEvent loggedEvent = null;
            _logObserver.When(o => o.OnNext(Arg.Any<MicrosoftLogEvent>()))
                        .Do(
                            ci =>
                            {
                                loggedEvent = ci.ArgAt<MicrosoftLogEvent>(0);
                            });

            _logger.Log(logEvent);

            loggedEvent.Should()
                       .NotBeNull();

            loggedEvent.Message.Should()
                       .Be("message 1" + Environment.NewLine + logEvent.Exception);

            loggedEvent.Level.Should()
                       .Be(MicrosoftLogLevel.Trace);

            loggedEvent.Id.Id.Should()
                       .Be(logEvent.Id.Id);

            loggedEvent.Id.Name.Should()
                       .Be(logEvent.Id.Name);

            loggedEvent.Error.Should()
                       .Be(logEvent.Exception);

            loggedEvent.State.Should()
                       .BeAssignableTo<IEnumerable<KeyValuePair<string, object>>>();

            ((IEnumerable<KeyValuePair<string, object>>) loggedEvent.State)
                .Should()
                .BeEquivalentTo(
                    new[]
                    {
                        new KeyValuePair<string, object>("{OriginalFormat}", logEvent.MessageTemplate.Format),
                        new KeyValuePair<string, object>("value1", 1)
                    });
        }
    }
}
