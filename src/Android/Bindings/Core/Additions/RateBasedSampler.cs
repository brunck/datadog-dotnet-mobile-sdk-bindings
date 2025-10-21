using Core.KotlinInterop;

// ReSharper disable once CheckNamespace
namespace Datadog.Android.Core.Sampling;

public partial class RateBasedSampler
{
    public RateBasedSampler(Func<float> sampleRateProvider) : this(new FuncOfFloatImplementor(sampleRateProvider))
    {
    }
}