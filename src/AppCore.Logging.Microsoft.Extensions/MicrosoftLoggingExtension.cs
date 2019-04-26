// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.DependencyInjection;
using AppCore.DependencyInjection.Facilities;

namespace AppCore.Logging.Microsoft.Extensions
{
    /// <summary>
    /// Provides Microsoft Logging based logging.
    /// </summary>
    public class MicrosoftLoggingExtension : FacilityExtension<ILoggingFacility>
    {
        /// <inheritdoc />
        protected override void RegisterComponents(IComponentRegistry registry, ILoggingFacility facility)
        {
            registry.Register<ILoggerProvider>()
                    .Add<MicrosoftLoggerProvider>()
                    .PerContainer()
                    .IfNotRegistered();
        }
    }
}
