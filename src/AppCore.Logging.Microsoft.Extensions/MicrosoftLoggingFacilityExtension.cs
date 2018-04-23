using AppCore.Logging;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    public class MicrosoftLoggingFacilityExtension : FacilityExtension<ILoggingFacility>
    {
        public MicrosoftLoggingFacilityExtension()
            : base(r => r.AddSingleton<ILoggerProvider, MicrosoftLoggerProvider>())
        {
        }
    }
}
