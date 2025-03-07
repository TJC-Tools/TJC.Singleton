namespace TJC.Singleton.Tests.Tests.ThreadSafety;

[TestClass]
public class NonThreadSafeInstanceTest
{
    /// <summary>
    /// This test is set as inconclusive, since it is not perfectly repeatable.
    /// <para>Sometimes all instances will be the same, but most of the time there will be some different instances.</para>
    /// <para>There will usually be 2-5 different instances out of 100 tries.</para>
    /// <para>Therefore, this can only be used as a sanity check to ensure that the other tests that follow this pattern are valid.</para>
    /// </summary>
    [TestMethod]
    public void NonThreadSafeSingletonHasMultipleInstances()
    {
        // Create 100 Instances of Singleton
        var singletons = MockSingletonFactory.GetInstances(
            () => MockSingletonNonThreadSafe.Instance,
            100
        );

        // Get Unique ID's from Instances
        var ids = singletons.DistinctBy(x => x.Id).Select(x => x.Id).ToList();

        // Create Message
        var instancesAmountMessage =
            $"[{ids.Count}/{singletons.Count}] Instances of [{nameof(MockSingletonNonThreadSafe)}] Exist";
        Trace.WriteLine(instancesAmountMessage);

        // Ensure there are multiple different instances of the non-thread safe singleton
        // This is only a sanity check
        if (ids.Count == 1)
            Assert.Inconclusive($"\nOnly {instancesAmountMessage}");
    }
}
