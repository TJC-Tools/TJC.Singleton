using TJC.Singleton.Tests.Interfaces;

namespace TJC.Singleton.Tests.Mocs;

internal class MocSingletonNonThreadSafe : IIdentifier
{
    private static MocSingletonNonThreadSafe? _instance;

    public static MocSingletonNonThreadSafe Instance =>
        _instance ??= new MocSingletonNonThreadSafe();

    public Guid Id { get; } = Guid.NewGuid();
}