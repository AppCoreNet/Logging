// Licensed under the MIT License.
// Copyright (c) 2018,2019 the AppCore .NET project.

using System.Collections.Generic;
using System.Linq;
using AppCore.DependencyInjection;
using FluentAssertions;
using Xunit;

namespace AppCore.Logging
{
    public class RegistrationTests
    {
        [Fact]
        public void LogginFacilityRegistersServices()
        {
            var registry = new TestComponentRegistry();

            registry.RegisterFacility<LoggingFacility>();

            IEnumerable<ComponentRegistration> registrations = registry.GetRegistrations()
                                                                       .ToList();

            registrations.Should()
                         .Contain(
                             cr =>
                                 cr.ContractType == typeof(ILoggerFactory)
                                 && cr.Lifetime == ComponentLifetime.Singleton
                                 && cr.Flags == ComponentRegistrationFlags.IfNoneRegistered);

            registrations.Should()
                         .Contain(
                             cr =>
                                 cr.ContractType == typeof(ILogger<>)
                                 && cr.Lifetime == ComponentLifetime.Transient
                                 && cr.Flags == ComponentRegistrationFlags.IfNoneRegistered);
        }
    }
}
