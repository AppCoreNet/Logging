// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.Diagnostics;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection.Builder
{
    public static class SerilogLoggingFacilityBuilderExtensions
    {
        public static IFacilityBuilder<ILoggingFacility> AddSerilog(this IFacilityBuilder<ILoggingFacility> builder)
        {
            Ensure.Arg.NotNull(builder, nameof(builder));
            return builder.AddExtension<SerilogLoggingFacilityExtension>();
        }
    }
}