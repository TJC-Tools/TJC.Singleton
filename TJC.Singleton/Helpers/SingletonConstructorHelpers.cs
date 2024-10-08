using System.Reflection;
using TJC.Singleton.Exceptions;

namespace TJC.Singleton.Helpers;

public static class SingletonConstructorHelpers
{
    #region Get Singlet Constructor

    /// <summary>
    /// Gets the singleton constructor for the type <seealso cref="T"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static ConstructorInfo GetSingletonConstructor<T>() =>
        GetSingletonConstructor(typeof(T));

    /// <summary>
    /// Gets the singleton constructor for the type.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    /// <exception cref="InvalidSingletonConstructorException"></exception>
    public static ConstructorInfo GetSingletonConstructor(Type type)
    {
        // Ensure there is no public constructor
        var publicConstructors = type.GetConstructors().Where(x => x.IsPublic).ToList();
        if (publicConstructors.Count != 0)
            throw new InvalidSingletonConstructorException($"[{type}] singleton should not have public constructor{(publicConstructors.Count > 1 ? "s" : string.Empty)}");

        // Ensure there is a non-public parameterless constructor
        var ctor = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, [], null) ??
                   throw new InvalidSingletonConstructorException($"[{type}] singleton is missing a non-public parameterless constructor");

        return ctor;
    }

    #endregion

    #region Check if Singleton has Valid Constructor

    /// <summary>
    /// Checks if a singleton of type <seealso cref="T"/> has a valid constructor.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static bool HasValidSingletonConstructor<T>() =>
        HasValidSingletonConstructor(typeof(T));

    /// <summary>
    /// Checks if the singleton has a valid constructor.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static bool HasValidSingletonConstructor(Type type)
    {
        try
        {
            GetSingletonConstructor(type);
            return true;
        }
        catch
        {
            return false;
        }
    }

    #endregion
}