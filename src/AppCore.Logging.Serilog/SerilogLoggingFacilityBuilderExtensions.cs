using AppCore.Logging;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    public static class SerilogLoggingFacilityBuilderExtensions
    {
        public static TBuilder UseSerilog<TBuilder>(this TBuilder builder)
            where TBuilder : IFacilityBuilder<ILoggingFacility>
        {
            builder.UseExtension(new SerilogLoggingFacilityExtension());
            return builder;
        }
    }
}