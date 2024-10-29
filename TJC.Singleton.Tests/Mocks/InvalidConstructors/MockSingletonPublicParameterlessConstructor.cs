namespace TJC.Singleton.Tests.Mocks.InvalidConstructors;

internal class MockSingletonPublicParameterlessConstructor
    : SingletonBase<MockSingletonPublicParameterlessConstructor>,
        IIdentifier
{
    public MockSingletonPublicParameterlessConstructor() { }

    public Guid Id { get; } = Guid.NewGuid();
}
