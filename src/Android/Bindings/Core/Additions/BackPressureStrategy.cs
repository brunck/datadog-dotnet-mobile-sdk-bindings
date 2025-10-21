using Core.KotlinInterop;

// ReSharper disable once CheckNamespace
namespace Datadog.Android.Core.Configuration;

public partial class BackPressureStrategy
{
    public Action<object> OnItemDropped
    {
        get
        {
            var kotlinResult = OnItemDroppedInterop();
            if (kotlinResult is not ActionOfObjectImplementor result)
            {
                throw new InvalidOperationException("Kotlin interop failure.");
            }

            return result.ToAction();
        }
    }

    public Action OnThresholdReached
    {
        get
        {
            var kotlinResult = OnThresholdReachedInterop();
            if (kotlinResult is not ActionImplementor result)
            {
                throw new InvalidOperationException("Kotlin interop failure.");
            }

            return result.ToAction();
        }
    }

    public BackPressureStrategy Copy(int capacity, Action onThresholdReached, Action<object> onItemDropped,
        BackPressureMitigation backpressureMitigation)
    {
        return CopyInterop(capacity, new ActionImplementor(onThresholdReached), new ActionOfObjectImplementor(onItemDropped),
            backpressureMitigation);
    }

    public BackPressureStrategy(int capacity, Action onThresholdReached, Action<object> onItemDropped
        , BackPressureMitigation backpressureMitigation)
        : this(capacity, new ActionImplementor(onThresholdReached), new ActionOfObjectImplementor(onItemDropped),
            backpressureMitigation)
    {
    }
}