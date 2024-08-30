namespace Datadog.Android.Event
{
    public interface IEventMapper<T> : IEventMapperBase where T : Java.Lang.Object
    {
        T? Map(T e);
    }
}