
// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    public static class MicrosoftLoggingFacilityBuilderExtensions
    {
        public static TBuilder UseMicrosoftExtensions<TBuilder>(this TBuilder builder)
            where TBuilder : IFacilityBuilder<ILoggingFacility>
        {
            builder.UseExtension(new MicrosoftLoggingFacilityExtension());
            return builder;
        }
    }
}