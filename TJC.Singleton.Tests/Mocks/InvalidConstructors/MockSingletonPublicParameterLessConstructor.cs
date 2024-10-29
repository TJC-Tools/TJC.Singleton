namespace TJC.Singleton.Tests.Mocks.InvalidConstructors;

internal class MockSingletonPublicParameterLessConstructor
    : SingletonBase<MockSingletonPublicParameterLessConstructor>,
        IIdentifier
{
    public MockSingletonPublicParameterLessConstructor() { }

    public Guid Id { get; } = Guid.NewGuid();
}
