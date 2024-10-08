using TJC.Singleton.Exceptions;
using TJC.Singleton.Helpers;

namespace TJC.Singleton;

/// <summary>
/// Creates a single instance of <seealso cref="TDerivedClass"/> that can be accessed through the <see cref="Instance"/> property.
/// </summary>
/// <typeparam name="TDerivedClass"></typeparam>
/// <exception cref="InvalidSingletonConstructorException">Must have a non-public parameterless constructor.</exception>
public abstract class SingletonBase<TDerivedClass> where TDerivedClass : SingletonBase<TDerivedClass>
{
    #region Fields

    private static Lazy<TDerivedClass> _instance = new(CreateInstance);

    #endregion

    #region Properties

    public static TDerivedClass Instance => _instance.Value;

    public static bool IsInstantiated => _instance.IsValueCreated;

    #endregion

    #region Methods

    /// <summary>
    /// This method is called when the singleton is first accessed.
    /// <para>It is used to create the singleton instance by calling the constructor of the derived class.</para>
    /// </summary>
    /// <returns></returns>
    /// <exception cref="SingletonInitializationException"></exception>
    private static TDerivedClass CreateInstance()
    {
        // Use reflection to create an instance of the derived class.
        var ctor = SingletonConstructorHelpers.GetSingletonConstructor<TDerivedClass>();
        return (TDerivedClass)ctor.Invoke(null) ??
               throw new SingletonInitializationException($"[{typeof(TDerivedClass)}] singleton failed to initialize");
    }

    /// <summary>
    /// This method is used to set the singleton instance to a specific value.
    /// <para>It is primarily used to set the instance to a predefined type.</para>
    /// <para>For example, singletons are often used as settings, which have predefined types, such as <c>Default</c>, <c>Verbose</c>, <c>Silent</c>, etc.</para>
    /// <para>This is set as <c>protected</c> so that it can only be accessed from within the singleton itself, since not all singletons should be able to be set.</para>
    /// </summary>
    /// <param name="value"></param>
    protected static void SetBaseInstance(TDerivedClass value)
    {
        _instance = new(() => value);
    }

    #endregion
}