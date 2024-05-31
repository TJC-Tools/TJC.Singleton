namespace TJC.Singleton;

public abstract class SingletonBaseClass<TMyClass> where TMyClass : SingletonBaseClass<TMyClass>, new()
{
    private static readonly Lazy<TMyClass> Lazy = new(() => new TMyClass());

    public static TMyClass Instance => Lazy.Value;
}