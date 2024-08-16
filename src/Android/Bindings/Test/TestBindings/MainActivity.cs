using Datadog.Android.Core.Configuration;
using Datadog.Android.Log;
using Datadog.Android.Ndk;
using Datadog.Android.Privacy;
using Object = Java.Lang.Object;

#pragma warning disable CS8604 // Possible null reference argument.

namespace TestBindings;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : Activity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        var config = new DDConfiguration.Builder("<CLIENT TOKEN>", "<ENV>", string.Empty, "<SERVICE NAME>")
            //.UseSite(<DatadogSite>)
            .Build();

        Datadog.Android.Datadog.Initialize(this, config, TrackingConsent.Granted);

        Datadog.Android.Datadog.Verbosity = (int)Android.Util.LogPriority.Verbose;
        var logsConfig = new LogsConfiguration.Builder()
            .Build();
        Logs.Enable(logsConfig);

        NdkCrashReports.Enable();

        var logger = new Logger.Builder()
            .SetNetworkInfoEnabled(false)
            .SetLogcatLogsEnabled(false)
            .SetName("TestLogger")
            .Build();

        logger.D("test debug message", null, new Dictionary<string, Object>
        {
            {"extra.attribute", "test.value"}
        });

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);
    }
}