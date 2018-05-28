// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.DependencyInjection.Builder;
using AppCore.Logging;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    public class MicrosoftLoggingFacilityExtension : FacilityExtension<ILoggingFacility>
    {
        public MicrosoftLoggingFacilityExtension()
        {
            Register<ILoggerProvider>()
                .Add<MicrosoftLoggerProvider>()
                .PerContainer()
                .IfNotRegistered();
        }
    }
}
