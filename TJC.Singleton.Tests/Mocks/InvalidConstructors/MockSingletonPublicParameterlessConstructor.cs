namespace TJC.Singleton.Tests.Mocks.InvalidConstructors;

internal class MockSingletonPublicParameterlessConstructor : SingletonBaseClass<MockSingletonPublicParameterlessConstructor>, IIdentifier
{
    public MockSingletonPublicParameterlessConstructor() { }

    public Guid Id { get; } = Guid.NewGuid();
}