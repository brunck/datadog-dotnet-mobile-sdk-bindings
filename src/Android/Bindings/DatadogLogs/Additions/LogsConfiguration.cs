using Datadog.Android.Event;
using Datadog.Android.Log.Model;

namespace Datadog.Android.Log;

public partial class LogsConfiguration
{
    public partial class Builder
    {
        public Builder SetEventMapper(IEventMapper<LogEvent> eventMapper)
        {
            return SetLogEventMapperInternal(eventMapper);
        }
    }
}