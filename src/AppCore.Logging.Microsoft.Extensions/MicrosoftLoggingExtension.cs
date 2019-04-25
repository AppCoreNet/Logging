// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.DependencyInjection.Facilities;
using AppCore.Logging;
using AppCore.Logging.Microsoft.Extensions;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
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
