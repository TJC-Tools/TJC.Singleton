namespace TJC.Singleton.Tests.Mocks.InvalidConstructors;

internal class MockSingletonPrivateConstructorWithParameters
    : SingletonBase<MockSingletonPrivateConstructorWithParameters>,
        IIdentifier
{
#pragma warning disable IDE0051
    private MockSingletonPrivateConstructorWithParameters(Guid? id = null)
#pragma warning restore IDE0051
    {
        Id = id ?? Guid.NewGuid();
    }

    public Guid Id { get; }
}
