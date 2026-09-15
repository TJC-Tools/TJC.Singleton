namespace TJC.Singleton.Tests.Tests.Constructor;


public class ConstructorTests
{
    [Fact]
    public void PrivateConstructorIsInitialized()
    {
        Assert.NotNull(MockSingletonValid.Instance);
    }

    [Fact]
    public void NoConstructorThrowsException()
    {
        Assert.Throws<InvalidSingletonConstructorException>(() =>
            MockSingletonNoConstructor.Instance
        );
    }

    [Fact]
    public void PublicParameterlessConstructorThrowsException()
    {
        Assert.Throws<InvalidSingletonConstructorException>(() =>
            MockSingletonPublicParameterLessConstructor.Instance
        );
    }

    [Fact]
    public void ProtectedConstructorWithParametersThrowsException()
    {
        Assert.Throws<InvalidSingletonConstructorException>(() =>
            MockSingletonProtectedConstructorWithParameters.Instance
        );
    }

    [Fact]
    public void PrivateConstructorWithParametersThrowsException()
    {
        Assert.Throws<InvalidSingletonConstructorException>(() =>
            MockSingletonPrivateConstructorWithParameters.Instance
        );
    }
}
