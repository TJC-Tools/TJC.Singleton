using TJC.Singleton.Factories;

namespace TJC.Singleton.Tests.Tests.Instantiated;

[TestClass]
public class IsInstantiatedTest
{
    [TestMethod]
    public void SingletonGetInstantiatedAfterBeingReferencedTest()
    {
        // MockSingletonInstantiated can only be used in this test and nowhere else, since object instances can persist between tests
        Assert.IsFalse(
            MockSingletonInstantiated.IsInstantiated,
            $"{nameof(MockSingletonInstantiated)} was already instantiated"
        );
        SingletonFactory.InstantiateAll(trace: true);
        Assert.IsTrue(
            MockSingletonInstantiated.IsInstantiated,
            $"{nameof(MockSingletonInstantiated)} is not instantiated"
        );
    }
}
