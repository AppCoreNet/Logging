// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.Diagnostics;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection.Builder
{
    /// <summary>
    /// Provides extension methods for registering the <see cref="SerilogLoggingFacilityExtension"/>
    /// with a <see cref="IFacilityBuilder{TFacility}"/> of <see cref="ILoggingFacility"/>.
    /// </summary>
    public static class SerilogLoggingFacilityBuilderExtensions
    {
        /// <summary>
        /// Registers the <see cref="SerilogLoggingFacilityExtension"/> with the <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IFacilityBuilder{TFacility}"/>.</param>
        /// <returns>The <paramref name="builder"/>.</returns>
        public static IFacilityBuilder<ILoggingFacility> UseSerilog(this IFacilityBuilder<ILoggingFacility> builder)
        {
            Ensure.Arg.NotNull(builder, nameof(builder));
            return builder.AddExtension<SerilogLoggingFacilityExtension>();
        }
    }
}