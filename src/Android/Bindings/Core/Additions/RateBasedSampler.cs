using Core.KotlinInterop;

// ReSharper disable once CheckNamespace
namespace Datadog.Android.Core.Sampling;

public partial class RateBasedSampler
{
    public RateBasedSampler(Action sampleRateProvider) : this(new ActionImplementor(sampleRateProvider))
    {
    }
}