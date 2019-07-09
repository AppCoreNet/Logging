// Licensed under the MIT License.
// Copyright (c) 2018,2019 the AppCore .NET project.

using System;
using AppCore.DependencyInjection.Facilities;
using AppCore.Diagnostics;
using AppCore.Logging;
using AppCore.Logging.Microsoft.Extensions;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    /// <summary>
    /// Provides extensions methods to register Microsoft Logging with the logging facility.
    /// </summary>
    public static class MicrosoftLoggingRegistrationExtensions
    {
        /// <summary>
        /// Registers the Microsoft Logging with the logging facility.
        /// </summary>
        /// <param name="builder">The <see cref="IFacilityBuilder{TFacility}"/>.</param>
        /// <param name="configure">The delegate which is invoked to configure the extension.</param>
        /// <returns>The <paramref name="builder"/>.</returns>
        public static IFacilityBuilder<ILoggingFacility> AddMicrosoftLogging(
            this IFacilityBuilder<ILoggingFacility> builder,
            Action<IFacilityExtensionBuilder<ILoggingFacility, MicrosoftLoggingExtension>> configure = null)
        {
            Ensure.Arg.NotNull(builder, nameof(builder));
            return builder.AddExtension(configure);
        }
    }
}