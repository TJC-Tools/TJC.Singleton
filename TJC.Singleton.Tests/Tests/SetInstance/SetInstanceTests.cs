namespace TJC.Singleton.Tests.Tests.SetInstance;

public class SetInstanceTests
{
    [Fact]
    public void SetInstance_PredefinedTypes()
    {
        MockSingletonPreDefinedTypes.SetInstance(MockSingletonPreDefinedTypes.Default);

        Assert.Equal("Setting1", MockSingletonPreDefinedTypes.Instance.Setting1);
        Assert.Equal("Setting2", MockSingletonPreDefinedTypes.Instance.Setting2);

        MockSingletonPreDefinedTypes.SetInstance(MockSingletonPreDefinedTypes.Empty);

        Assert.Equal(string.Empty, MockSingletonPreDefinedTypes.Instance.Setting1);
        Assert.Equal(string.Empty, MockSingletonPreDefinedTypes.Instance.Setting2);

        MockSingletonPreDefinedTypes.SetInstance(MockSingletonPreDefinedTypes.Alphabet);

        Assert.Equal("ABC", MockSingletonPreDefinedTypes.Instance.Setting1);
        Assert.Equal("DEF", MockSingletonPreDefinedTypes.Instance.Setting2);

        MockSingletonPreDefinedTypes.SetInstance(MockSingletonPreDefinedTypes.Numbers);

        Assert.Equal("123", MockSingletonPreDefinedTypes.Instance.Setting1);
        Assert.Equal("456", MockSingletonPreDefinedTypes.Instance.Setting2);

        MockSingletonPreDefinedTypes.SetInstance(MockSingletonPreDefinedTypes.Symbols);

        Assert.Equal("!@#", MockSingletonPreDefinedTypes.Instance.Setting1);
        Assert.Equal("$%^", MockSingletonPreDefinedTypes.Instance.Setting2);
    }
}
