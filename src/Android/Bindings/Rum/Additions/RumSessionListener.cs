namespace Datadog.Android.Rum
{
    public class RumSessionListener : Java.Lang.Object, IRumSessionListener
    {
        public event EventHandler<RumSessionEventArgs>? SessionStarted;

        public void OnSessionStarted(string sessionId, bool isDiscarded)
        {
            SessionStarted?.Invoke(this, new RumSessionEventArgs(sessionId, isDiscarded));
        }
    }
}
