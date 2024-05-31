namespace TJC.Singleton.Tests.Mocks.InvalidConstructors;

internal class MockSingletonPublicConstructor : SingletonBaseClass<MockSingletonPublicConstructor>, IIdentifier
{
    public MockSingletonPublicConstructor() { }

    public Guid Id { get; } = Guid.NewGuid();
}