namespace TJC.Singleton.Tests.Mocks.Valid;

/// <summary>
/// This singleton is an example of the proper intended use of the <see cref="SingletonBaseClass{TMyClass}"/>.
/// </summary>
internal class MockSingletonValid : SingletonBaseClass<MockSingletonValid>, IIdentifier
{
    private MockSingletonValid() { }

    public Guid Id { get; } = Guid.NewGuid();
}