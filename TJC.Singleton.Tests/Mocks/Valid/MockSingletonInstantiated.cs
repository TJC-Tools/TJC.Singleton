namespace TJC.Singleton.Tests.Mocks.Valid;

internal class MockSingletonInstantiated : SingletonBaseClass<MockSingletonInstantiated>, IIdentifier
{
    private MockSingletonInstantiated() { }

    public Guid Id { get; } = Guid.NewGuid();
}