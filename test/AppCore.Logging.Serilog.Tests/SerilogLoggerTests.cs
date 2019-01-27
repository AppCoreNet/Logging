// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using NSubstitute;
using Serilog;
using Serilog.Events;
using Xunit;
using SerilogEvent = Serilog.Events.LogEvent;
using SerilogEventLevel = Serilog.Events.LogEventLevel;

namespace AppCore.Logging.Serilog
{
    public class SerilogLoggerTests
    {
        private readonly ILogger _logger;
        private readonly IObserver<SerilogEvent> _logObserver;

        public SerilogLoggerTests()
        {
            _logObserver = Substitute.For<IObserver<SerilogEvent>>();
            _logObserver.OnNext(Arg.Any<SerilogEvent>());

            var config = new LoggerConfiguration();
            config.MinimumLevel.Verbose();
            config.WriteTo.Observers(o => o.Subscribe(_logObserver));

            _logger = new SerilogLogger(config.CreateLogger());
        }

        [Fact]
        public void Log_Writes_SerilogEvent()
        {
            var logEvent = new LogEvent(
                DateTimeOffset.Now,
                LogLevel.Trace,
                new LogEventId(new Random().Next(), "eventName"),
                new LogMessageTemplate("message"),
                new[] { LogProperty.Create("value1", 1)},
                new Exception());

            _logger.Log(logEvent);

            _logObserver.Received()
                .OnNext(Arg.Is<SerilogEvent>(
                    serilogEvent =>
                        serilogEvent.Timestamp == logEvent.Timestamp
                        && serilogEvent.MessageTemplate.Text == logEvent.MessageTemplate.Format
                        && serilogEvent.Level == (SerilogEventLevel) logEvent.Level
                        && serilogEvent.Exception == logEvent.Exception
                        && serilogEvent.Properties[SerilogPropertyNames.EventId].Equals(new ScalarValue(logEvent.Id))
                        && serilogEvent.Properties["value1"].Equals(new ScalarValue(1))
                ));
        }
    }
}
