using Datadog.Legacy.Trace.Api.Interceptor;
using Java.Lang;

// ReSharper disable once CheckNamespace
namespace Datadog.OpenTracing;

public partial class DDSpan
{
    public IMutableSpan? SetOperationNameForMutableSpan(string? p0)
    {
        SetOperationName(p0);
        return this;
    }

    public IMutableSpan? SetResourceNameForMutableSpan(string? p0)
    {
        SetResourceName(p0);
        return this;
    }

    public IMutableSpan? SetServiceNameForMutableSpan(string? p0)
    {
        SetServiceName(p0);
        return this;
    }

    public IMutableSpan? SetSpanTypeForMutableSpan(string? p0)
    {
        SetSpanType(p0);
        return this;
    }

    public IMutableSpan? SetTagForMutableSpan(string? p0, bool p1)
    {
        SetTag(p0, p1);
        return this;
    }

    public IMutableSpan? SetTagForMutableSpan(string? p0, Number? p1)
    {
        SetTag(p0, p1);
        return this;
    }

    public IMutableSpan? SetTagForMutableSpan(string? p0, string? p1)
    {
        SetTag(p0, p1);
        return this;
    }

    public IMutableSpan? SetErrorForMutableSpan (bool p0)
    {
        SetError(p0);
        return this;
    }
}