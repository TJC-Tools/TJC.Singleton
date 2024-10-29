namespace TJC.Singleton.Tests.Mocks.InvalidConstructors;

internal class MockSingletonNoConstructor : SingletonBase<MockSingletonNoConstructor>, IIdentifier
{
    public Guid Id { get; } = Guid.NewGuid();
}
