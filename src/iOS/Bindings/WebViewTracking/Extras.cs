using Foundation;
using WebKit;

namespace Datadog.iOS.WebViewTracking;

public partial class DDWebViewTracking
{
    public static float MaxSampleRate = 100.0F;

    public static void Enable(WKWebView webView)
    {
        Enable(webView, new NSSet<NSString>(), MaxSampleRate);
    }
}