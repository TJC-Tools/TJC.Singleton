namespace TJC.Singleton.Tests.Mocks.Valid;

/// <summary>
/// This singleton is an example of the proper intended use of the <see cref="SingletonBase{TMyClass}"/>.
/// </summary>
internal class MockSingletonValid : SingletonBase<MockSingletonValid>, IIdentifier
{
    private MockSingletonValid() { }

    public Guid Id { get; } = Guid.NewGuid();
}
