namespace TJC.Singleton.Helpers;

public static class SingletonIdentifierHelpers
{
    public static bool IsConcreteSingleton(Type type)
    { 
        // Ensure type is a concrete class
        if (!type.IsClass || type.IsAbstract)
            return false;

        // Ensure type derives from singleton
        var openGenericType = typeof(SingletonBaseClass<>);
        
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