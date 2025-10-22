# .NET Bindings for the Datadog Mobile SDKs
For use with .NET for Android and .NET for iOS applications, including .NET MAUI.

## What is Datadog?
See the main [Datadog](https://www.datadoghq.com/) site.

These .NET bindings apply only to the Datadog Mobile SDKs for both iOS and Android. No other Datadog functionality is included.

For more information, please refer to the [Datadog iOS SDK repository](https://github.com/DataDog/dd-sdk-ios) and the [Datadog Android SDK repository](https://github.com/DataDog/dd-sdk-android).

Submodules are included for each SDK.

# Platforms

## iOS

Requires iOS 17.0 or later.

See the [iOS-specific documentation](src/iOS) for this package.

[Sample](src/iOS/T/)

## Android

Requires Android 26 or later.

The [Android SDK](https://github.com/DataDog/dd-sdk-android/tree/master) is broken out into separate packages, so you only have to install the ones that correspond to the functionality you are using.

> Bindings for the integration libraries are not available at this time.

[Sample](src/Android/Bindings/Test/TestBindings/)

The various packages (with links to documentation) are:

* [Logs](TODO) - [Docs](https://docs.datadoghq.com/logs/log_collection/android/)
* [RUM](TODO) - [Docs](https://docs.datadoghq.com/real_user_monitoring/android/)
* [SessionReplay](TODO) - [Docs](https://docs.datadoghq.com/real_user_monitoring/session_replay/mobile/setup_and_configuration/?tab=android)
* [SessionReplay.Material](TODO)
* [Trace](TODO) - [Docs](https://docs.datadoghq.com/tracing/trace_collection/automatic_instrumentation/dd_libraries/android/)
* [Trace.Otel](TODO) - [Docs](https://docs.datadoghq.com/tracing/trace_collection/custom_instrumentation/android/otel/)
* [WebView](TODO) - [Docs](https://docs.datadoghq.com/real_user_monitoring/mobile_and_tv_monitoring/web_view_tracking/?tab=android#prerequisites)
* [Ndk](TODO)

### Initialization
See the [sample app](src/Android/Bindings/Test/TestBindings) for an example.

## Binding Policies
The major/minor/patch versions mirror those of the Maven packages. For example, version `2.11.0.1` binds the `2.11.0` version of the `com.datadoghq:dd-sdk-android-core` library.

> The revision number is incremented when a new version of the NuGet package needs to be built but there are no updates to the library itself.
 
## Support
Support here is limited to issues related to the bindings only. For documentation and support using the Datadog Mobile SDKs, please refer to their [documentation](https://docs.datadoghq.com/).

Not everything has been tested. Use at your own risk; although any issues past compilation/missing bindings are likely in the SDK itself rather than the bindings.

#### Note
> There is currently no .NET MAUI cross-platform code for initialization. Refer to the Datadog mobile documentation for how to initialize the SDKs for each platform.

## Contributing

Not accepting contributions at this time.

## License

This repository is licensed under the MIT License. See the LICENSE file for details.

### NOTICE

This repository includes software developed at Datadog (https://www.datadoghq.com/), which is licensed under the [Apache License 2.0](https://www.apache.org/licenses/LICENSE-2.0). 

Those portions are Copyright 2019 Datadog, Inc.

For more information, please refer to the [Datadog Android SDK repository](https://github.com/DataDog/dd-sdk-android) or the [Datadog iOS SDK repository](https://github.com/DataDog/dd-sdk-ios).