namespace TJC.Singleton.Tests.Helpers;

internal static class MocSingletonFactory
{
    public static List<T> GetInstances<T>(Func<T> getSingleton, int amount)
    {
        var singletons = new List<T>();
        var threads    = new List<Thread>();

        for (var i = 0; i < amount; i++)
            threads.Add(new Thread(() => singletons.Add(getSingleton())));

        foreach (var thread in threads)
            thread.Start();
        foreach (var thread in threads)
            thread.Join();

        return singletons;
    }
}