# .NET Bindings for the Datadog Mobile iOS SDK - SessionReplay

These bindings are for the SessionReplay framework.

These bindings are only for iOS; tvOS is not included.

## Prerequisites

Before using the iOS SDK bindings, make sure you have the following prerequisites:

- iOS 17.0 or higher
- .NET 8 or higher

## Usage

See the [Datadog iOS SDK repository](https://github.com/DataDog/dd-sdk-ios) for more information about initialization for any given piece of functionality.

All functionality requires you to initialize the SDK before use. The Datadog documentation has more information; the basics are to initialize in `FinishedLaunching()`: 

1. Import the `Datadog.iOS.SessionReplay` namespace:

    ```csharp
    using Datadog.iOS.SessionReplay;
    ```

2. Init the DDSessionReplay:

     ```csharp
    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        // other SDK Initialization code here

        DDSessionReplayConfiguration replayConfig = new DDSessionReplayConfiguration(
            100.0F, 
            DDTextAndInputPrivacyLevel.MaskAll, 
            DDImagePrivacyLevel.MaskAll, 
            DDTouchPrivacyLevel.Hide);
            
        DDSessionReplay.Enable(replayConfig);
    }
    ```