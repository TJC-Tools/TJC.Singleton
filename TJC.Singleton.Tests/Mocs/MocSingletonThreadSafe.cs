namespace TJC.Singleton.Tests.Mocs;

internal class MocSingletonThreadSafe : SingletonBaseClass<MocSingletonThreadSafe>, IIdentifier
{
    public Guid Id { get; } = Guid.NewGuid();
}