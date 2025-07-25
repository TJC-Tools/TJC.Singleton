﻿namespace TJC.Singleton.Tests.Tests.Constructor;

[TestClass]
public class ConstructorTests
{
    [TestMethod]
    public void PrivateConstructorIsInitialized()
    {
        Assert.IsNotNull(MockSingletonValid.Instance);
    }

    [TestMethod]
    public void NoConstructorThrowsException()
    {
        Assert.ThrowsException<InvalidSingletonConstructorException>(() =>
            MockSingletonNoConstructor.Instance
        );
    }

    [TestMethod]
    public void PublicParameterlessConstructorThrowsException()
    {
        Assert.ThrowsException<InvalidSingletonConstructorException>(() =>
            MockSingletonPublicParameterLessConstructor.Instance
        );
    }

    [TestMethod]
    public void ProtectedConstructorWithParametersThrowsException()
    {
        Assert.ThrowsException<InvalidSingletonConstructorException>(() =>
            MockSingletonProtectedConstructorWithParameters.Instance
        );
    }

    [TestMethod]
    public void PrivateConstructorWithParametersThrowsException()
    {
        Assert.ThrowsException<InvalidSingletonConstructorException>(() =>
            MockSingletonPrivateConstructorWithParameters.Instance
        );
    }
}
