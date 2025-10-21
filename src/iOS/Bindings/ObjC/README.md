# .NET Bindings for the Datadog Mobile iOS SDK - ObjC

These bindings are only for iOS; tvOS is not included.

> **NOTE:** These bindings are only against the Objective-C interop layer for the iOS SDK. As such, only code that is part of that layer is currently available.

Using the Objective-C layer requires you to import much of the iOS SDK. In contrast, the Swift layer allows you to import only the specific packages you need.

## Prerequisites

Before using the iOS SDK bindings, make sure you have the following prerequisites:

- iOS 17.0 or higher
- .NET 8 or higher

## Usage

See the [Datadog iOS SDK repository](https://github.com/DataDog/dd-sdk-ios) for more information about initialization for any given piece of functionality.

All functionality requires you to initialize the SDK before use. The Datadog documentation has more information; the basics are to initialize in `FinishedLaunching()`: 

1. Import the `Datadog.iOS.ObjC` namespace:

    ```csharp
    using Datadog.iOS.ObjC;
    ```

2. Add package references for any other needed functionality not already included in this module, which are:

    * [CrashReporting](https://www.nuget.org/packages/Bcr.Datadog.iOS.CR)
    * [SessionReplay](https://www.nuget.org/packages/Bcr.Datadog.iOS.SR)
    * [WebViewTracking](https://www.nuget.org/packages/Bcr.Datadog.iOS.Web)

3. Import any of the other namespaces for the needed functionality: 

    ```csharp
    using Datadog.iOS.CrashReporting;
    using Datadog.iOS.SessionReplay;
    using Datadog.iOS.WebViewTracking;
    ```

4. Initialize the Datadog SDK with your client token and environment:

    ```csharp
    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        // Initialize the Datadog configuration
        DDConfiguration config = new DDConfiguration("<client token>", "<environment>");
        config.Service = "<service name>";
        config.Site = "<Datadog Site>";

        // Initialize the Datadog SDK with the configuration and tracking consent
        DDDatadog.Initialize(config, trackingConsent);

        // Enable Datadog logs
        DDLogs.Enable(new DDLogsConfiguration(null));

        // ...
    }
    ```

For more information on using the Datadog .NET Mobile SDK, refer to the [official documentation](https://docs.datadoghq.com/).

## FAQ

### Why am I getting errors like `Could not find a part of the path...` when I add this NuGet package to my app and try to build it using Visual Studio on Windows?

This is the notorius "max path" bug in Visual Studio that limits paths to 260 characters. It particularly affects .NET for iOS apps, as `.xcframework` files are folders with very deep structures. 

The `.xcframework` paths have been shortened as much as is practical. You have the following options:

1. First, upvote the [Visual Studio Dev Community](https://developercommunity.visualstudio.com/t/Allow-building-running-and-debugging-a/351628) issue. This problem has been known for years, and yet still no action has been taken.
2. Enable the Windows registry setting for long path support.
2. Perform all your NuGet restoration and builds on the command line.
2. Shorten your source code path to be VERY short, as in one or two characters (if possible)
3. Shorten your Git repository path of your clone to also be as short as possible.
4. You may also need configure a `nuget.config` file to shorten the location of your NuGet packages. For example:
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <config>
    <add key="globalPackagesFolder" value="C:\n" />
  </config>
</configuration>
```



## License

This project is licensed under the [MIT License](LICENSE).

This product includes software developed at Datadog (https://www.datadoghq.com/), used under the [Apache License, v2.0](https://github.com/DataDog/dd-sdk-ios/blob/develop/LICENSE)

Those portions are Copyright 2019 Datadog, Inc.
