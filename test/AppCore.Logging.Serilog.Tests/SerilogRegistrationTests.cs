// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.DependencyInjection;
using FluentAssertions;
using Xunit;

namespace AppCore.Logging.Serilog
{
    public class SerilogRegistrationTests
    {
        [Fact]
        public void AddSerilogRegistersProvider()
        {
            var registry = new TestComponentRegistry();

            registry.RegisterFacility<LoggingFacility>()
                    .AddSerilog();

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
