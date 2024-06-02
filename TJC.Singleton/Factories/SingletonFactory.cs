using System.Diagnostics;
using System.Reflection;
using TJC.Singleton.Helpers;

namespace TJC.Singleton.Factories;

public static class SingletonFactory
{
    #region Constants

    private const string InstanceName = nameof(SingletonBaseClass<PlaceholderSingleton>.Instance);

    private class PlaceholderSingleton : SingletonBaseClass<PlaceholderSingleton>;

    #endregion

    public static void InstantiatedAll(bool trace = true,
                                       bool throwIfFailed = false)
    {
        var failedToInstantiate = new List<string>();
        var singletons = GetSingletonTypes();

        if (trace)
            Trace.WriteLine($"{singletons.Count} Singletons Found");

        foreach (var singleton in singletons)
            if (!singleton.Instantiate(trace))
                failedToInstantiate.Add(singleton.Name);

        if (throwIfFailed && failedToInstantiate.Count > 0)
            throw new Exception($"{string.Join(", ", failedToInstantiate)}");
    }

    public static List<Type> GetSingletonTypes()
    {
        var singletons = new List<Type>();

        // Iterate through all assemblies & types to find all singletons
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (var type in assembly.GetTypes())
            {
                if (!SingletonIdentifierHelpers.IsConcreteSingleton(type))
                    continue; // Skip types that are not singletons

                if (!SingletonConstructorHelpers.HasValidSingletonConstructor(type))
                    continue; // Skip singletons with invalid constructors

                singletons.Add(type);
            }
        }

        return singletons;
    }

    private static bool Instantiate(this Type singleton, bool trace)
    {
        if (trace)
            Trace.WriteLine($"[{singleton.Name}] Instantiating");
        var instanceProp = singleton.GetProperty(InstanceName,
                                                 BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                        ?? throw new Exception($"[{singleton.Name}] does not have property [{InstanceName}]");
        var instanceValue = instanceProp.GetValue(singleton);
        if (trace)
            Trace.WriteLine($"[{singleton.Name}] {(instanceValue != null ? "Instantiated" : "Failed to Instantiate")}");
        return instanceValue != null;
    }
}