using Microsoft.Extensions.Logging;
using System.Reflection;
using TJC.Singleton.Helpers;

namespace TJC.Singleton.Factories;

/// <summary>
/// Factory for creating <seealso cref="SingletonBase{TDerivedClass}"/>'s.
/// </summary>
public static class SingletonFactory
{
    #region Constants

    private const string InstanceName = nameof(SingletonBase<PlaceholderSingleton>.Instance);

    private class PlaceholderSingleton : SingletonBase<PlaceholderSingleton>;

    #endregion

    /// <summary>
    /// Instantiate all singletons in the current app domain.
    /// </summary>
    /// <param name="throwIfFailed"></param>
    /// <param name="logger"></param>
    /// <param name="logLevel"></param>
    /// <exception cref="Exception"></exception>
    public static void InstantiateAll(ILogger? logger = null, LogLevel logLevel = LogLevel.Trace, bool throwIfFailed = false)
    {
        var failedToInstantiate = new List<string>();
        var singletons = GetSingletonTypes();

        logger?.Log(logLevel, "{count} Singletons Found", singletons.Count);

        foreach (var singleton in singletons)
            if (!singleton.Instantiate(logger, logLevel))
                failedToInstantiate.Add(singleton.Name);

        if (throwIfFailed && failedToInstantiate.Count > 0)
            throw new Exception($"{string.Join(", ", failedToInstantiate)}");
    }

    /// <summary>
    /// Get all singleton types in the current app domain.
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Instantiates a singleton of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="logger"></param>
    /// <param name="logLevel"></param>
    /// <returns></returns>
    public static bool Instantiate<T>(ILogger? logger = null, LogLevel logLevel = LogLevel.Trace) =>
        Instantiate(typeof(T), logger, logLevel);

    /// <summary>
    /// Instantiates a singleton of given type.
    /// </summary>
    /// <param name="singleton"></param>
    /// <param name="logger"></param>
    /// <param name="logLevel"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    private static bool Instantiate(this Type singleton, ILogger? logger = null, LogLevel logLevel = LogLevel.Trace)
    {
        logger?.Log(logLevel, "[{name}] Instantiating", singleton.Name);
        var instanceProp =
            singleton.GetProperty(
                InstanceName,
                BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy
            ) ?? throw new Exception($"[{singleton.Name}] does not have property [{InstanceName}]");
        var instanceValue = instanceProp.GetValue(singleton);
        logger?.Log(logLevel, "[{name}] {result}", singleton.Name, instanceValue != null ? "Instantiated" : "Failed to Instantiate");
        return instanceValue != null;
    }
}
