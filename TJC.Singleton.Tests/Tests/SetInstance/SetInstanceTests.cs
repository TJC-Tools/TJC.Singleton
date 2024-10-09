namespace TJC.Singleton.Tests.Tests.SetInstance;

[TestClass]
public class SetInstanceTests
{
    [TestMethod]
    public void SetInstance_PredefinedTypes()
    {
        MockSingletonPreDefinedTypes.SetInstance(MockSingletonPreDefinedTypes.Default);

        Assert.AreEqual("Setting1", MockSingletonPreDefinedTypes.Instance.Setting1);
        Assert.AreEqual("Setting2", MockSingletonPreDefinedTypes.Instance.Setting2);

        MockSingletonPreDefinedTypes.SetInstance(MockSingletonPreDefinedTypes.Empty);

        Assert.AreEqual(string.Empty, MockSingletonPreDefinedTypes.Instance.Setting1);
        Assert.AreEqual(string.Empty, MockSingletonPreDefinedTypes.Instance.Setting2);

        MockSingletonPreDefinedTypes.SetInstance(MockSingletonPreDefinedTypes.Alphabet);

        Assert.AreEqual("ABC", MockSingletonPreDefinedTypes.Instance.Setting1);
        Assert.AreEqual("DEF", MockSingletonPreDefinedTypes.Instance.Setting2);

        MockSingletonPreDefinedTypes.SetInstance(MockSingletonPreDefinedTypes.Numbers);

        Assert.AreEqual("123", MockSingletonPreDefinedTypes.Instance.Setting1);
        Assert.AreEqual("456", MockSingletonPreDefinedTypes.Instance.Setting2);

        MockSingletonPreDefinedTypes.SetInstance(MockSingletonPreDefinedTypes.Symbols);

        Assert.AreEqual("!@#", MockSingletonPreDefinedTypes.Instance.Setting1);
        Assert.AreEqual("$%^", MockSingletonPreDefinedTypes.Instance.Setting2);
    }
}