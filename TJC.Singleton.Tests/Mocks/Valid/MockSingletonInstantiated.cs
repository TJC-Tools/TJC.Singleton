namespace TJC.Singleton.Tests.Mocks.Valid;

internal class MockSingletonInstantiated : SingletonBase<MockSingletonInstantiated>, IIdentifier
{
    private MockSingletonInstantiated() { }

    public Guid Id { get; } = Guid.NewGuid();
}
