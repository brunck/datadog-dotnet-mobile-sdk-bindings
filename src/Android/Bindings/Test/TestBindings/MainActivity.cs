using Datadog.Android.Core.Configuration;
using Datadog.Android.Log;
using Datadog.Android.Ndk;
using Datadog.Android.Privacy;
using Datadog.Android.Rum;
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

        var rumConfiguration = new RumConfiguration.Builder("AppId").TrackLongTasks()
                                                              .TrackLongTasks()
                                                              .TrackFrustrations(true)
                                                              .TrackBackgroundEvents(true)
                                                              .TrackNonFatalAnrs(true)
                                                              .Build();

        Datadog.Android.Rum.Rum.Enable(rumConfiguration);
        
        _ = Datadog.Android.Rum.GlobalRumMonitor.Instance;
        _ = Datadog.Android.Rum.GlobalRumMonitor.Get();

        var logger = new Logger.Builder()
            .SetNetworkInfoEnabled(false)
            .SetLogcatLogsEnabled(false)
            .SetName("TestLogger")
            .Build();

        logger.D("test debug message", null, new Dictionary<string, Object>
        {
            {"extra.attribute", "test.value"}
        });

        var nativeException = new Java.Lang.Exception("test exception");
        logger.E("This does not get logged", nativeException, new Dictionary<string, Object>
        {
            { "error.stack", new Java.Lang.String(Environment.StackTrace) }
        });

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);
    }
}