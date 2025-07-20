namespace TJC.Singleton.Helpers;

/// <summary>
/// Helpers for identifying details about <seealso cref="SingletonBase{TDerivedClass}"/>.
/// </summary>
public static class SingletonIdentifierHelpers
{
    /// <summary>
    /// Determines if a type is a concrete singleton.
    /// <para>I.e. If it is a <c>non-abstract class</c> that derives from <see cref="SingletonBase{TDerivedClass}"/>, or a class that does (recursively).</para>
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static bool IsConcreteSingleton(Type type)
    {
        // Ensure type is a concrete class
        if (!type.IsClass || type.IsAbstract)
            return false;

        // Ensure type derives from singleton
        var openGenericType = typeof(SingletonBase<>);

        var baseType = type.BaseType;
        while (baseType != null)
        {
            if (baseType.IsGenericType && baseType.GetGenericTypeDefinition() == openGenericType)
                return true;
            baseType = baseType.BaseType;
        }

        return false;
    }
}
