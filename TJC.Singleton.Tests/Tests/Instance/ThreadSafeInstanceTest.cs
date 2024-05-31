namespace TJC.Singleton.Tests.Tests.Instance;

[TestClass]
public class ThreadSafeInstanceTest
{
    /// <summary>
    /// This test creates 1000 instances of the thread safe singleton to ensure that only one instance can ever be created
    /// </summary>
    [TestMethod]
    public void ThreadSafeSingletonHasSingleInstances()
    {
        // Create 1000 Instances of Singleton
        var singletons = MocSingletonFactory.GetInstances(() => MocSingletonThreadSafe.Instance, 1000);

        // Get Unique ID's from Instances
        var ids = singletons.DistinctBy(x => x.Id).Select(x => x.Id).ToList();

        // Create Message
        var instancesAmountMessage = $"[{ids.Count}/{singletons.Count}] Instances of [{nameof(MocSingletonThreadSafe)}] Exist";
        Trace.WriteLine(instancesAmountMessage);

        // Ensure there is only one instance of the thread safe singleton
        Assert.AreEqual(1, ids.Count, $"\nMultiple {instancesAmountMessage}\n• {string.Join("\n• ", ids)}");
    }
}