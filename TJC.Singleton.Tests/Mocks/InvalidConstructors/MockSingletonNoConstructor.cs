namespace TJC.Singleton.Tests.Mocks.InvalidConstructors;

internal class MockSingletonNoConstructor : SingletonBaseClass<MockSingletonNoConstructor>, IIdentifier
{
    public Guid Id { get; } = Guid.NewGuid();
}