namespace TJC.Singleton.Tests.Mocks.Valid;

internal class MockSingletonInstantiated : SingletonBaseClass<MockSingletonInstantiated>, IIdentifier
{
    private MockSingletonInstantiated() {}//=> IsInstantiated = true;

    public Guid Id { get; } = Guid.NewGuid();

    //public static bool IsInstantiated { get; private set; }
}