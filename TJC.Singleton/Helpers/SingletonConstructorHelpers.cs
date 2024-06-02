using System.Reflection;
using TJC.Singleton.Exceptions;

namespace TJC.Singleton.Helpers;

public static class SingletonConstructorHelpers
{
    #region Get Singlet Constructor

    public static ConstructorInfo GetSingletonConstructor<T>() =>
        GetSingletonConstructor(typeof(T));

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

    public static bool HasValidSingletonConstructor<T>() =>
        HasValidSingletonConstructor(typeof(T));

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