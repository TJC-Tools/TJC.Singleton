namespace TJC.Singleton.Tests.Mocks.InvalidConstructors;

internal class MockSingletonPrivateConstructorWithParameters : SingletonBaseClass<MockSingletonPrivateConstructorWithParameters>, IIdentifier
{
    private MockSingletonPrivateConstructorWithParameters(Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
    }

    public Guid Id { get; }
}