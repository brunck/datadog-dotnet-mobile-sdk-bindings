# .NET Bindings for the Datadog Mobile iOS SDK - CrashReporting

These bindings are for the DatadogCrashReporting framework.

These bindings are only for iOS; tvOS is not included.

## Prerequisites

Before using the iOS SDK bindings, make sure you have the following prerequisites:

- iOS 17.0 or higher
- .NET 8 or higher

## Usage

See the [Datadog iOS SDK repository](https://github.com/DataDog/dd-sdk-ios) for more information about initialization for any given piece of functionality.

All functionality requires you to initialize the SDK before use. The Datadog documentation has more information; the basics are to initialize in `FinishedLaunching()`: 

1. Import the `Datadog.iOS.CrashReporting` namespace:

    ```csharp
    using Datadog.iOS.CrashReporting;
    ```

2. Init the DDCrashReporter:

     ```csharp
    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        // other SDK Initialization code here

        DDCrashReporter.Enable();
    }
    ```