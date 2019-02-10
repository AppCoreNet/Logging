// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.DependencyInjection.Facilities;
using AppCore.Diagnostics;
using Serilog;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
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
        /// <remarks>Uses the <see cref="Log.Logger"/> instance.</remarks>
        /// <param name="builder">The <see cref="IFacilityBuilder{TFacility}"/>.</param>
        /// <returns>The <paramref name="builder"/>.</returns>
        public static IFacilityBuilder<ILoggingFacility> UseSerilog(this IFacilityBuilder<ILoggingFacility> builder)
        {
            Ensure.Arg.NotNull(builder, nameof(builder));
            return builder.AddExtension<SerilogLoggingFacilityExtension>();
        }

        /// <summary>
        /// Registers the <see cref="SerilogLoggingFacilityExtension"/> with the <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IFacilityBuilder{TFacility}"/>.</param>
        /// <param name="logger">The root logger to use.</param>
        /// <returns>The <paramref name="builder"/>.</returns>
        public static IFacilityBuilder<ILoggingFacility> UseSerilog(this IFacilityBuilder<ILoggingFacility> builder, ILogger logger)
        {
            Ensure.Arg.NotNull(builder, nameof(builder));
            Ensure.Arg.NotNull(logger, nameof(logger));
            return builder.AddExtension(new SerilogLoggingFacilityExtension(logger));
        }
    }
}