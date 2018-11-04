// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.Diagnostics;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection.Builder
{
    /// <summary>
    /// Provides extensions methods for registering <see cref="MicrosoftLoggingFacilityExtension"/> with
    /// a <see cref="IFacilityBuilder{TFacility}"/> of <see cref="ILoggingFacility"/>.
    /// </summary>
    public static class MicrosoftLoggingFacilityBuilderExtensions
    {
        /// <summary>
        /// Registers the <see cref="MicrosoftLoggingFacilityExtension"/> with the <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IFacilityBuilder{TFacility}"/>.</param>
        /// <returns>The <paramref name="builder"/>.</returns>
        public static IFacilityBuilder<ILoggingFacility> UseMicrosoftLogging(
            this IFacilityBuilder<ILoggingFacility> builder)
        {
            Ensure.Arg.NotNull(builder, nameof(builder));
            return builder.AddExtension<MicrosoftLoggingFacilityExtension>();
        }
    }
}