using IO.OpenTracing;
using Java.Lang;
using Kotlin.Jvm.Functions;
using Exception = System.Exception;

// ReSharper disable once CheckNamespace
namespace Datadog.Android.Trace;

public static class SpanExtensions
{
   /// <summary>
   /// Helper method to attach an Exception to this Span.
   /// The Exception information (class name, message, and stack trace) will be added to
   /// this Span as standard Error Tags.
   /// </summary>
   /// <param name="span">The Span to which the error will be attached.</param>
   /// <param name="exception">The Exception you want to log.</param>
   public static void SetError(this ISpan span, Exception exception)
   {
       var throwable = new Throwable(exception.Message);
       SpanExtKt.SetError(span, throwable);
   }

   /// <summary>
   /// Helper method to attach an error message to this Span.
   /// The error message will be added to this Span as a standard Error Tag.
   /// </summary>
   /// <param name="span">The Span to which the error message will be attached.</param>
   /// <param name="message">The error message you want to attach.</param>
   public static void SetError(this ISpan span, string message)
   {
       SpanExtKt.SetError(span, message);
   }

   /// <summary>
   /// Wraps the provided lambda within a Span.
   /// </summary>
   /// <typeparam name="T">The type returned by the lambda.</typeparam>
   /// <param name="operationName">The name of the Span created around the lambda.</param>
   /// <param name="parentSpan">The parent Span (default is null).</param>
   /// <param name="activate">Whether the created Span should be made active for the current thread (default is true).</param>
   /// <param name="block">The lambda function traced by this newly created Span.</param>
   /// <returns>The result of the lambda function.</returns>
   public static T WithinSpan<T>(string operationName, ISpan? parentSpan, bool activate, Func<ISpan, T> block)
   {
       var function = new FuncWrapper<T>(block);
       var result = SpanExtKt.WithinSpan(operationName, parentSpan, activate, function);
       if (result is T typedResult)
       {
           return typedResult;
       }

       throw new InvalidCastException("Result cannot be cast to the specified type.");
   }

   private class FuncWrapper<T> : Java.Lang.Object, IFunction1
   {
       private readonly Func<ISpan, T> _func;

       public FuncWrapper(Func<ISpan, T> func)
       {
           _func = func;
       }

       public Java.Lang.Object Invoke(Java.Lang.Object? span)
       {
           ArgumentNullException.ThrowIfNull(span);
           var result = _func((ISpan)span);
           return result as Java.Lang.Object ??
                  throw new InvalidCastException("Result cannot be cast to Java.Lang.Object");
       }
   }
}