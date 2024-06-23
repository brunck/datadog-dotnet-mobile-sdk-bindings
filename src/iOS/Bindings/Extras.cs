using CoreFoundation;
using ObjCRuntime;

namespace Datadog.iOS
{
    public partial class DDLoggerConfiguration
    {
        public DDLoggerConfiguration(string? service = null, string? name = null) : this(service, name, false, true, true, 100, DDLogLevel.Debug, false)
        {
        }
    }

    public partial class DDURLSessionInstrumentation
    {
        public static void Disable<T>() where T : INSUrlSessionDataDelegate
        {
            Disable(new Class(typeof(T)));
        }
    }
}
