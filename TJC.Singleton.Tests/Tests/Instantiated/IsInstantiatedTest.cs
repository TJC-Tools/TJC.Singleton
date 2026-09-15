using TJC.Singleton.Factories;
using TJC.Singleton.Tests.Mocks.Logging;

namespace TJC.Singleton.Tests.Tests.Instantiated;


public class IsInstantiatedTest
{
    [Fact]
    public void SingletonGetInstantiatedAfterBeingReferencedTest()
    {
        // MockSingletonInstantiated can only be used in this test and nowhere else, since object instances can persist between tests
        Assert.False(
            MockSingletonInstantiated.IsInstantiated,
            $"{nameof(MockSingletonInstantiated)} was already instantiated"
        );
        SingletonFactory.InstantiateAll(MockLogger.Default);
        Assert.True(
            MockSingletonInstantiated.IsInstantiated,
            $"{nameof(MockSingletonInstantiated)} is not instantiated"
        );
    }
}
