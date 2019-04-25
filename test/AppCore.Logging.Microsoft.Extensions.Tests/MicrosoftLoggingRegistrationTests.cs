// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.DependencyInjection;
using FluentAssertions;
using Xunit;

namespace AppCore.Logging.Microsoft.Extensions
{
    public class MicrosoftLoggingRegistrationTests
    {
        [Fact]
        public void AddMicrosoftLoggingRegistersProvider()
        {
            var registry = new TestComponentRegistry();

            registry.RegisterFacility<LoggingFacility>()
                    .AddMicrosoftLogging();

            registry.GetRegistrations()
                    .Should()
                    .Contain(
                        cr =>
                            cr.ContractType == typeof(ILoggerProvider)
                            && cr.Lifetime == ComponentLifetime.Singleton
                            && cr.Flags == ComponentRegistrationFlags.IfNotRegistered);
        }
    }
}
