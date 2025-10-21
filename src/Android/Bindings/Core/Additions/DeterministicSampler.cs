using Core.KotlinInterop;

// ReSharper disable once CheckNamespace
namespace Datadog.Android.Core.Sampling;

public partial class DeterministicSampler
{
    public DeterministicSampler(Func<Java.Lang.Object, long> idConverter, double sampleRate) : 
        this(new FuncOfObjectAndLongImplementor(idConverter), sampleRate)
    {
    }

    public DeterministicSampler(Func<Java.Lang.Object, long> idConverter, float sampleRate) : 
        this(new FuncOfObjectAndLongImplementor(idConverter), sampleRate)
    {
    }

    public DeterministicSampler(Func<Java.Lang.Object, long> idConverter, Func<float> sampleRateProvider) : 
        this(new FuncOfObjectAndLongImplementor(idConverter), new FuncOfFloatImplementor(sampleRateProvider))
    {
    }
}