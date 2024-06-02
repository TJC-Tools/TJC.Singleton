namespace TJC.Singleton.Tests.Helpers;

internal static class MocSingletonFactory
{
    /// <summary>
    /// Use multiple threads to attempt to get multiple instances of a singleton.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="getSingleton"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public static List<T> GetInstances<T>(Func<T> getSingleton, int amount)
    {
        var singletons = new List<T>();
        var threads = new List<Thread>();

        for (var i = 0; i < amount; i++)
            threads.Add(new Thread(() => singletons.Add(getSingleton())));

        foreach (var thread in threads)
            thread.Start();
        foreach (var thread in threads)
            thread.Join();

        return singletons;
    }
}