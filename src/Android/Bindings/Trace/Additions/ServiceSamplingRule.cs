namespace Datadog.Android.Trace.Common.Sampling
{
    public partial class SamplingRule
    {
        public partial class ServiceSamplingRule
        {
            protected override Java.Lang.ICharSequence? GetRelevantStringFormatted(Java.Lang.Object? span)
            {
                return (Java.Lang.String?)GetRelevantString(span);
            }
        }
    }
}
