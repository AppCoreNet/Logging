// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using AppCore.DependencyInjection.Facilities;
using AppCore.Diagnostics;
using Serilog;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    /// <summary>
    /// Provides extension methods to register Serilog with the logging facility.
    /// </summary>
    public static class SerilogRegistrationExtensions
    {
        /// <summary>
        /// Registers Serilog with the logging facility.
        /// </summary>
        /// <param name="builder">The <see cref="IFacilityBuilder{TFacility}"/>.</param>
        /// <returns>The <paramref name="builder"/>.</returns>
        public static IFacilityExtensionBuilder<ILoggingFacility, SerilogLoggingExtension> AddSerilog(
            this IFacilityBuilder<ILoggingFacility> builder)
        {
            Ensure.Arg.NotNull(builder, nameof(builder));
            return builder.AddExtension<SerilogLoggingExtension>();
        }

        /// <summary>
        /// Configures logging to use the globally-shared <see cref="Log.Logger"/> instance.
        /// </summary>
        /// <param name="builder">The logging extension builder.</param>
        /// <param name="dispose">Whether to call <see cref="Log.CloseAndFlush"/>.</param>
        /// <returns>The <paramref name="builder"/>.</returns>
        public static IFacilityExtensionBuilder<ILoggingFacility, SerilogLoggingExtension> UseStaticLogger(
            this IFacilityExtensionBuilder<ILoggingFacility, SerilogLoggingExtension> builder,
            bool dispose = true)
        {
            Ensure.Arg.NotNull(builder, nameof(builder));
            builder.Extension.Logger = null;
            builder.Extension.Dispose = dispose;
            return builder;
        }

        /// <summary>
        /// Configures logging to use the specified <see cref="ILogger"/>.
        /// </summary>
        /// <param name="builder">The logging extension builder.</param>
        /// <param name="logger">The root logger to use.</param>
        /// <param name="dispose">Whether to dispose the logger.</param>
        /// <returns>The <paramref name="builder"/>.</returns>
        public static IFacilityExtensionBuilder<ILoggingFacility, SerilogLoggingExtension> UseLogger(
            this IFacilityExtensionBuilder<ILoggingFacility, SerilogLoggingExtension> builder,
            ILogger logger, bool dispose = false)
        {
            Ensure.Arg.NotNull(builder, nameof(builder));
            builder.Extension.Logger = logger;
            builder.Extension.Dispose = dispose;
            return builder;
        }

        /// <summary>
        /// Configures logging to use the specified <see cref="LoggerConfiguration"/>.
        /// </summary>
        /// <param name="builder">The logging extension builder.</param>
        /// <param name="config">The logger configuration to use.</param>
        /// <returns>The <paramref name="builder"/>.</returns>
        public static IFacilityExtensionBuilder<ILoggingFacility, SerilogLoggingExtension> UseConfiguration(
            this IFacilityExtensionBuilder<ILoggingFacility, SerilogLoggingExtension> builder,
            LoggerConfiguration config)
        {
            Ensure.Arg.NotNull(builder, nameof(builder));
            builder.Extension.Logger = config.CreateLogger();
            builder.Extension.Dispose = true;
            return builder;
        }

        /// <summary>
        /// Configures logging to use the specified <see cref="LoggerConfiguration"/>.
        /// </summary>
        /// <param name="builder">The logging extension builder.</param>
        /// <param name="configure">The callback used to configure the logger.</param>
        /// <returns>The <paramref name="builder"/>.</returns>
        public static IFacilityExtensionBuilder<ILoggingFacility, SerilogLoggingExtension> UseConfiguration(
            this IFacilityExtensionBuilder<ILoggingFacility, SerilogLoggingExtension> builder,
            Action<LoggerConfiguration> configure)
        {
            Ensure.Arg.NotNull(configure, nameof(configure));
            var config = new LoggerConfiguration();
            configure(config);
            return UseConfiguration(builder, config);
        }
    }
}
