# .NET Bindings for the Datadog Mobile SDKs
For use with .NET for Android and .NET for iOS applications, including .NET MAUI.

## What is Datadog?
See the main [Datadog](https://www.datadoghq.com/) site.

These bindings apply only to the Datadog Mobile SDKs for both iOS and Android. No other Datadog functionality is included.

For more information, please refer to the [Datadog iOS SDK repository](https://github.com/DataDog/dd-sdk-ios) and the [Datadog Android SDK repository](https://github.com/DataDog/dd-sdk-android).

## NuGet Packages

### iOS

See the [iOS-specific documentation]() for this package.

### Android
The Android SDK is broken out into separate packages, so you only have to install the ones that correspond to the functionality you are using.

The various packages are:

* 

## Binding Policies
The major/minor/patch versions mirror those of the Maven packages. For example, version `2.11.0.1` binds the `2.11.0` version of the `com.datadoghq:dd-sdk-android-core` library.

* The revision number is incremented when a new version of the NuGet package needs to be built but there are no updates to the library itself.
 
## Support
Support here is limited to issues related to the bindings only. For documentation and support using the Datadog Mobile SDKs, please refer to their [documentation](https://docs.datadoghq.com/).

#### Note
There is currently no .NET MAUI cross-platform code for initialization. Refer to the Datadog mobile documentation for how to initialize the SDKs for each platform.

## License

This package is licensed under the MIT License. See the LICENSE file for details.

### NOTICE

These packages include software developed at Datadog (https://www.datadoghq.com/).

Copyright 2019 Datadog, Inc.

For more information, please refer to the [Datadog Android SDK repository](https://github.com/DataDog/dd-sdk-android).