using TJC.Singleton.Exceptions;
using TJC.Singleton.Helpers;

namespace TJC.Singleton;

/// <summary>
/// Creates a single instance of <seealso cref="TDerivedClass"/> that can be accessed through the <see cref="Instance"/> property.
/// </summary>
/// <typeparam name="TDerivedClass"></typeparam>
/// <exception cref="InvalidSingletonConstructorException">Must have a non-public parameterless constructor.</exception>
public abstract class SingletonBaseClass<TDerivedClass> where TDerivedClass : SingletonBaseClass<TDerivedClass>
{
    #region Fields

    private static readonly Lazy<TDerivedClass> _instance = new(CreateInstance);

    #endregion

    #region Properties

    public static TDerivedClass Instance => _instance.Value;

    public static bool IsInstantiated => _instance.IsValueCreated;

    #endregion

    #region Methods

    private static TDerivedClass CreateInstance()
    {
        // Use reflection to create an instance of the derived class.
        var ctor = SingletonConstructorHelpers.GetSingletonConstructor<TDerivedClass>();
        return (TDerivedClass)ctor.Invoke(null) ?? 
               throw new SingletonInitializationException($"[{typeof(TDerivedClass)}] singleton failed to initialize");
    }

    #endregion
}