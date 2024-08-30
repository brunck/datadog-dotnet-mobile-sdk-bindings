namespace Datadog.Android.Log.Model;

public partial class LogEvent
{
    public Error? ErrorDetails => GetError();

    public Logger LoggerDetails => GetLogger();

    public Network? NetworkDetails => GetNetwork();

    public Status StatusDetails => GetStatus();

    public DatadogDeviceInfo DD => DDInternal();

    public string DDTags
    {
        get => DdTagsGet();
        set => SetDdtags(value);
    }
}


