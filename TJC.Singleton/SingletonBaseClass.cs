using TJC.Singleton.Exceptions;

namespace TJC.Singleton;

/// <summary>
/// Creates a single instance of <seealso cref="TMyClass"/> that can be accessed through the <see cref="Instance"/> property.
/// </summary>
/// <typeparam name="TMyClass"></typeparam>
/// <exception cref="InvalidSingletonConstructorException">Must have a non-public parameterless constructor.</exception>
public abstract class SingletonBaseClass<TMyClass> where TMyClass : SingletonBaseClass<TMyClass>
{
    private static readonly Lazy<TMyClass> _instance = new(CreateInstance);

    public static TMyClass Instance => _instance.Value;

    private static TMyClass CreateInstance()
    {
        // Ensure there is no public constructor
        var pubConstructors = typeof(TMyClass).GetConstructors().Where(x => x.IsPublic).ToList();
        if (pubConstructors.Count != 0)
            throw new InvalidSingletonConstructorException($"[{typeof(TMyClass)}] singleton should not have public constructor{(pubConstructors.Count > 1 ? "s" : string.Empty)}");

        // Ensure there is a non-public parameterless constructor
        var ctor = typeof(TMyClass).GetConstructor(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic, null, [], null) ?? 
            throw new InvalidSingletonConstructorException($"[{typeof(TMyClass)}] singleton is missing a non-public parameterless constructor");

        // Use reflection to create an instance of the derived class
        return (TMyClass)ctor.Invoke(null) ?? throw new SingletonInitializationException($"[{typeof(TMyClass)}] singleton failed to initialize");
    }
}