// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.DependencyInjection.Builder;
using AppCore.Logging;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    public class SerilogLoggingFacilityExtension : FacilityExtension<ILoggingFacility>
    {
        protected override void RegisterComponents(IComponentRegistry registry, ILoggingFacility facility)
        {
            registry.Register<ILoggerProvider>()
                    .Add<SerilogLoggerProvider>()
                    .PerContainer()
                    .IfNotRegistered();
        }
    }
}
