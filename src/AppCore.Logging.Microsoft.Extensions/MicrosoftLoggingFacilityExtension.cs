// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.DependencyInjection.Builder;
using AppCore.Logging;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    /// <summary>
    /// Provides Microsoft.Extensions.Logging based logging.
    /// </summary>
    public class MicrosoftLoggingFacilityExtension : FacilityExtension<ILoggingFacility>
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
