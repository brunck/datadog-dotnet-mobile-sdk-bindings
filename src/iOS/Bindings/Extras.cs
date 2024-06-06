using CoreFoundation;

namespace Datadog.iOS
{
    public partial class DDLoggerConfiguration
    {
        public DDLoggerConfiguration(string? service = null, string? name = null) : this(service, name, false, true, true, 100, DDLogLevel.Debug, false)
        {
            
        }
    }
}
