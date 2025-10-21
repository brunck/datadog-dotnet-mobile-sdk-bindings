// ReSharper disable once CheckNamespace
namespace Core.KotlinInterop;

internal class ActionOfObjectImplementor : Java.Lang.Object, Kotlin.Jvm.Functions.IFunction1
{
    private readonly Action<object> _action;

    public ActionOfObjectImplementor(Action<object> action)
    {
        _action = action;
    }

    public Java.Lang.Object Invoke(Java.Lang.Object? obj)
    {
        if (obj != null)
        {
            _action(JavaObjectToObject(obj));
        }

        return Kotlin.Unit.Instance;
    }

    public Action<object> ToAction()
    {
        return _action;
    }

    private static object JavaObjectToObject(Java.Lang.Object javaObj)
    {
        // String conversion
        if (javaObj is Java.Lang.String javaString)
        {
            return javaString.ToString();
        }

        // Integer conversions
        if (javaObj is Java.Lang.Integer javaInteger)
        {
            return javaInteger.IntValue();
        }

        // Boolean conversions
        if (javaObj is Java.Lang.Boolean javaBoolean)
        {
            return javaBoolean.BooleanValue();
        }

        // Double conversions
        if (javaObj is Java.Lang.Double javaDouble)
        {
            return javaDouble.DoubleValue();
        }

        // Float conversions
        if (javaObj is Java.Lang.Float javaFloat)
        {
            return javaFloat.FloatValue();
        }

        // Long conversions
        if (javaObj is Java.Lang.Long javaLong)
        {
            return javaLong.LongValue();
        }

        // Byte conversions
        if (javaObj is Java.Lang.Byte javaByte)
        {
            return javaByte.ByteValue();
        }

        // Short conversions
        if (javaObj is Java.Lang.Short javaShort)
        {
            return javaShort.ShortValue();
        }

        // Character conversions
        if (javaObj is Java.Lang.Character javaCharacter)
        {
            return javaCharacter.CharValue();
        }

        throw new ArgumentException("Unsupported Java.Lang.Object type");
    }
}

internal class ActionImplementor : Java.Lang.Object, Kotlin.Jvm.Functions.IFunction0
{
    private readonly Action _action;

    public ActionImplementor(Action action)
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

internal class FuncImplementorBase : Java.Lang.Object
{
    protected static object JavaObjectToObject(Java.Lang.Object javaObj)
    {
        // String conversion
        if (javaObj is Java.Lang.String javaString)
        {
            return javaString.ToString();
        }

        // Integer conversions
        if (javaObj is Java.Lang.Integer javaInteger)
        {
            return javaInteger.IntValue();
        }

        // Boolean conversions
        if (javaObj is Java.Lang.Boolean javaBoolean)
        {
            return javaBoolean.BooleanValue();
        }

        // Double conversions
        if (javaObj is Java.Lang.Double javaDouble)
        {
            return javaDouble.DoubleValue();
        }

        // Float conversions
        if (javaObj is Java.Lang.Float javaFloat)
        {
            return javaFloat.FloatValue();
        }

        // Long conversions
        if (javaObj is Java.Lang.Long javaLong)
        {
            return javaLong.LongValue();
        }

        // Byte conversions
        if (javaObj is Java.Lang.Byte javaByte)
        {
            return javaByte.ByteValue();
        }

        // Short conversions
        if (javaObj is Java.Lang.Short javaShort)
        {
            return javaShort.ShortValue();
        }

        // Character conversions
        if (javaObj is Java.Lang.Character javaCharacter)
        {
            return javaCharacter.CharValue();
        }

        throw new ArgumentException("Unsupported Java.Lang.Object type");
    }
}

internal class FuncOfFloatImplementor : FuncImplementor<Java.Lang.Float>
{
    public FuncOfFloatImplementor(Func<float> func) : base(() => (Java.Lang.Float)func())
    {
    }
}

internal class FuncOfObjectAndLongImplementor : FuncImplementor<Java.Lang.Object, Java.Lang.Long>
{
    public FuncOfObjectAndLongImplementor(Func<Java.Lang.Object, long> func) : base(obj => (Java.Lang.Long)func(obj))
    {
    }
}

internal class FuncOfObjectImplementor : FuncImplementor<Java.Lang.Object, Java.Lang.Object>
{
    public FuncOfObjectImplementor(Func<object, object> func) : base(obj => (Java.Lang.Object)func(obj))
    {
    }

    
}

internal class FuncImplementor<TResult> : FuncImplementorBase, Kotlin.Jvm.Functions.IFunction0 where TResult : Java.Lang.Object
{
    private readonly Func<TResult> _func;

    public FuncImplementor(Func<TResult> func)
    {
        _func = func;
    }

    public Java.Lang.Object Invoke()
    {
        return (Java.Lang.Object)_func();
    }

    public Func<TResult> ToFunc()
    {
        return _func;
    }
}

internal class FuncImplementor<T1, TResult> : FuncImplementorBase, Kotlin.Jvm.Functions.IFunction1
    where T1 : Java.Lang.Object
    where TResult : Java.Lang.Object
{
    private readonly Func<T1, TResult> _func;

    public FuncImplementor(Func<T1, TResult> func)
    {
        _func = func;
    }

    public Java.Lang.Object Invoke(Java.Lang.Object? obj)
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }
        return _func((T1)obj);
    }

    public Func<T1, TResult> ToFunc()
    {
        return _func;
    }
}

public static class DictionaryConverter
{
    public static IDictionary<string, Java.Lang.Object> ToJavaDictionary(this IDictionary<string, object> netDictionary)
    {
        var javaDictionary = new Dictionary<string, Java.Lang.Object>();
        foreach (var kvp in netDictionary)
        {
            var javaObject = ObjectToJavaObject(kvp.Value);
            javaDictionary.Add(kvp.Key, javaObject);
        }
        return javaDictionary;
    }

    public static IDictionary<string, object> ToDotNetDictionary(this IDictionary<string, Java.Lang.Object> javaDictionary)
    {
        var netDictionary = new Dictionary<string, object>();
        foreach (var kvp in javaDictionary)
        {
            netDictionary.Add(kvp.Key, JavaObjectToObject(kvp.Value));
        }
        return netDictionary;
    }

    private static Java.Lang.Object ObjectToJavaObject(object obj)
    {
        return (Java.Lang.Object)obj;
    }

    private static object JavaObjectToObject(Java.Lang.Object javaObj)
    {
        // String conversion
        if (javaObj is Java.Lang.String javaString)
        {
            return javaString.ToString();
        }

        // Integer conversions
        if (javaObj is Java.Lang.Integer javaInteger)
        {
            return javaInteger.IntValue();
        }

        // Boolean conversions
        if (javaObj is Java.Lang.Boolean javaBoolean)
        {
            return javaBoolean.BooleanValue();
        }

        // Double conversions
        if (javaObj is Java.Lang.Double javaDouble)
        {
            return javaDouble.DoubleValue();
        }

        // Float conversions
        if (javaObj is Java.Lang.Float javaFloat)
        {
            return javaFloat.FloatValue();
        }

        // Long conversions
        if (javaObj is Java.Lang.Long javaLong)
        {
            return javaLong.LongValue();
        }

        // Byte conversions
        if (javaObj is Java.Lang.Byte javaByte)
        {
            return javaByte.ByteValue();
        }

        // Short conversions
        if (javaObj is Java.Lang.Short javaShort)
        {
            return javaShort.ShortValue();
        }

        // Character conversions
        if (javaObj is Java.Lang.Character javaCharacter)
        {
            return javaCharacter.CharValue();
        }

        throw new ArgumentException("Unsupported Java.Lang.Object type");
    }

}
