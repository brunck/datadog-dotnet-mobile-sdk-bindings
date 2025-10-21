using Datadog.Android.Api;

namespace Datadog.Android.SessionReplay;

public partial class SessionReplay
{
    /// <summary>
    /// Start recording session replay data.
    /// </summary>
    /// <param name="sdk">
    ///     The SDK instance to get the feature from. If not provided, the default SDK instance will be used.
    /// </param>
    public void StartRecording(ISdkCore? sdk = null)
    {
        sdk ??= Datadog.Instance;
        StartRecordingInternal(sdk);
    }

    /// <summary>
    /// Stop recording session replay data.
    /// </summary>
    /// <param name="sdk">
    ///     The SDK instance to get the feature from. If not provided, the default SDK instance will be used.
    /// </param>
    public void StopRecording(ISdkCore? sdk = null)
    {
        sdk ??= Datadog.Instance;
        StopRecordingInternal(sdk);
    }
}