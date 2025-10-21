namespace Datadog.OpenTracing;

public partial class DDSpanContext
{
    public Java.Lang.IIterable? BaggageItems()
    {
        var dictionary = BaggageItemsAsDictionary();
        if (dictionary == null)
        {
            return null;
        }

        var javaMap = new Java.Util.HashMap();
        foreach (var kvp in dictionary)
        {
            javaMap.Put(new Java.Lang.String(kvp.Key), new Java.Lang.String(kvp.Value));
        }

        var entryList = new Java.Util.ArrayList(javaMap.EntrySet());

        return entryList;
    }
}
