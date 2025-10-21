using Android.Database.Sqlite;
using IO.OpenTracing;
using Kotlin.Jvm.Functions;

namespace Datadog.Android.Trace.Sqlite;

public static class SqlLiteExtensions
{
    /// <summary>
    /// Wraps the transactionTraced method to provide a more idiomatic C# API.
    /// </summary>
    /// <typeparam name="T">The type returned by the lambda.</typeparam>
    /// <param name="database">The SQLiteDatabase instance.</param>
    /// <param name="operationName">The name of the operation.</param>
    /// <param name="exclusive">Whether the transaction is exclusive.</param>
    /// <param name="body">The lambda function traced by this transaction.</param>
    /// <returns>The result of the lambda function.</returns>
    public static T TransactionTraced<T>(this SQLiteDatabase database, string operationName, bool exclusive, Func<ISpan, SQLiteDatabase, T> body)
    {
        var function = new FuncWrapper<T>(body);
        var result = SqliteDatabaseExtKt.TransactionTraced(database, operationName, exclusive, function);

        if (result is T typedResult)
        {
            return typedResult;
        }

        throw new InvalidCastException("Result cannot be cast to the specified type.");
    }

    private class FuncWrapper<T> : Java.Lang.Object, IFunction2
    {
        private readonly Func<ISpan, SQLiteDatabase, T> _func;

        public FuncWrapper(Func<ISpan, SQLiteDatabase, T> func)
        {
            _func = func;
        }

        public Java.Lang.Object Invoke(Java.Lang.Object? span, Java.Lang.Object? database)
        {
            ArgumentNullException.ThrowIfNull(span);
            ArgumentNullException.ThrowIfNull(database);

            var result = _func((ISpan)span, (SQLiteDatabase)database);
            return result as Java.Lang.Object ?? throw new InvalidCastException("Result cannot be cast to Java.Lang.Object");
        }
    }
}