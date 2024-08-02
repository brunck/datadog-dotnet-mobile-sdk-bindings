// ReSharper disable once CheckNamespace
namespace Datadog.Trace.Core;

// ReSharper disable once InconsistentNaming
public partial class DDSpan
{
    public int SamplingPriority()
    {
        return (int)SamplingPriorityInternal()!;
    }
}