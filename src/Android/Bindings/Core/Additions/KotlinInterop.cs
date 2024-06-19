// ReSharper disable once CheckNamespace
namespace Core.KotlinInterop;

internal class ActionOfObjectWrapper : Java.Lang.Object, Kotlin.Jvm.Functions.IFunction1
{
    private readonly Action<object> _action;

    public ActionOfObjectWrapper(Action<object> action)
    {
        _action = action;
    }

    public Java.Lang.Object Invoke(Java.Lang.Object? obj)
    {
        if (obj != null)
        {
            _action(obj);
        }

        return Kotlin.Unit.Instance;
    }

    public Action<object> ToAction()
    {
        return _action;
    }
}

internal class ActionWrapper : Java.Lang.Object, Kotlin.Jvm.Functions.IFunction0
{
    private readonly Action _action;

    public ActionWrapper(Action action)
    {
        _action = action;
    }

    public Java.Lang.Object Invoke()
    {
        _action();
        return Kotlin.Unit.Instance;
    }

    public Action ToAction()
    {
        return _action;
    }
}