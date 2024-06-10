namespace TJC.Singleton.Tests.Tests.ThreadSafety;

[TestClass]
public class ValidInstanceTest
{
    /// <summary>
    /// This test creates 100 instances of the thread safe singleton to ensure that only one instance can ever be created.
    /// </summary>
    [TestMethod]
    public void ValidSingletonHasSingleInstance()
    {
        // Create 100 Instances of Singleton
        var singletons = MockSingletonFactory.GetInstances(() => MockSingletonValid.Instance, 100);

        // Get Unique ID's from Instances
        var ids = singletons.DistinctBy(x => x.Id).Select(x => x.Id).ToList();

        // Create Message
        var instancesAmountMessage = $"[{ids.Count}/{singletons.Count}] Instances of [{nameof(MockSingletonValid)}] Exist";
        Trace.WriteLine(instancesAmountMessage);

        // Ensure there is only one instance of the thread safe singleton
        Assert.AreEqual(1, ids.Count, $"\nMultiple {instancesAmountMessage}\n• {string.Join("\n• ", ids)}");
    }
}