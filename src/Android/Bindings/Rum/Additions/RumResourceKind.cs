namespace Datadog.Android.Rum
{
    public partial class RumResourceKind
    {
        public static RumResourceKind FromMimeType(string mimeType)
        {
            var companion = new Companion(null);
            return companion.FromMimeType(mimeType);
        }
    }
}