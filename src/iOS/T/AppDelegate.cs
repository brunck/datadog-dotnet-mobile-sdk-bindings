using Datadog.iOS;

namespace T
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow? Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // create a new window instance based on the screen size
            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            // initialize the Datadog SDK
            DDConfiguration config = new DDConfiguration(
                "<client token>", "<environment>
            );

            config.Service = "<service name>";
            config.Site = <Datadog Site>;

            DDDatadog.Initialize(config, DDTrackingConsent.Granted);
            DDDatadog.VerbosityLevel = DDSDKVerbosityLevel.Debug;
            DDLogs.Enable(new DDLogsConfiguration(null));

            DDCrashReporter.Enable();

            // init the logger
            DDLoggerConfiguration logConfig = new DDLoggerConfiguration();
            logConfig.Service = "<log service>";
            logConfig.NetworkInfoEnabled = true;
            logConfig.PrintLogsToConsole = true;
            logConfig.BundleWithRumEnabled = false;

            DDLogger logger = DDLogger.Create(logConfig);

            // test logger
            logger.Debug("Logging a debug message.");

            // create a UIViewController with a single UILabel
            var vc = new UIViewController();
            vc.View!.AddSubview(new UILabel(Window!.Frame)
            {
                BackgroundColor = UIColor.SystemBackground,
                TextAlignment = UITextAlignment.Center,
                Text = "Hello, iOS!",
                AutoresizingMask = UIViewAutoresizing.All,
            });
            Window.RootViewController = vc;

            // make the window visible
            Window.MakeKeyAndVisible();

            return true;
        }
    }
}
