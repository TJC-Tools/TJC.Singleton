namespace TJC.Singleton.Tests.Mocks.NonThreadSafe;

/// <summary>
/// This singleton is intentionally non-thread safe.
/// </summary>
internal class MockSingletonNonThreadSafe : IIdentifier
{
    private static MockSingletonNonThreadSafe? _instance;

    public static MockSingletonNonThreadSafe Instance =>
        _instance ??= new MockSingletonNonThreadSafe();

    public Guid Id { get; } = Guid.NewGuid();
}