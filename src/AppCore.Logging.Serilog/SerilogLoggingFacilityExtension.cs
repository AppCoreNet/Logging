using AppCore.DependencyInjection;

namespace AppCore.Logging
{
    public class SerilogLoggingFacilityExtension : FacilityExtension<ILoggingFacility>
    {
        public SerilogLoggingFacilityExtension()
            : base(r => r.AddSingleton<ILoggerProvider, SerilogLoggerProvider>())
        {
        }
    }
}
