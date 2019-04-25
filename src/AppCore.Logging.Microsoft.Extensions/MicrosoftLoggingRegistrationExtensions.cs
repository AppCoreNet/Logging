// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.DependencyInjection.Facilities;
using AppCore.Diagnostics;

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
        /// <returns>The <paramref name="builder"/>.</returns>
        public static IFacilityExtensionBuilder<ILoggingFacility, MicrosoftLoggingExtension> AddMicrosoftLogging(
            this IFacilityBuilder<ILoggingFacility> builder)
        {
            Ensure.Arg.NotNull(builder, nameof(builder));
            return builder.AddExtension<MicrosoftLoggingExtension>();
        }
    }
}