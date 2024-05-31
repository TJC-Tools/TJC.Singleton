namespace TJC.Singleton.Tests.Mocks.InvalidConstructors;

internal class MockSingletonProtectedConstructorWithParameters : SingletonBaseClass<MockSingletonPrivateConstructorWithParameters>, IIdentifier
{
    protected MockSingletonProtectedConstructorWithParameters(Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
    }

    public Guid Id { get; }
}