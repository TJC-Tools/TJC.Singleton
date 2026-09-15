using TJC.Singleton.Exceptions;
using TJC.Singleton.Factories;
using TJC.Singleton.Helpers;
using TJC.Singleton.Tests.Mocks.InvalidConstructors;
using TJC.Singleton.Tests.Mocks.Valid;

namespace TJC.Singleton.Tests.Tests;

[TestClass]
public class SingletonFactoryTests
{
    [TestMethod]
    public void Instantiate_ValidSingleton_ReturnsTrue()
    {
        Assert.IsTrue(SingletonFactory.Instantiate<MockSingletonValid>());
    }

    [TestMethod]
    public void Instantiate_TypeWithoutInstanceProperty_ThrowsException()
    {
        Assert.ThrowsException<Exception>(() => SingletonFactory.Instantiate<string>());
    }

    [TestMethod]
    public void GetSingletonConstructor_MultiplePublicConstructors_DescribesPluralConstructors()
    {
        var exception = Assert.ThrowsException<InvalidSingletonConstructorException>(() =>
            SingletonConstructorHelpers.GetSingletonConstructor(typeof(MultiplePublicConstructors))
        );

        StringAssert.Contains(exception.Message, "constructors");
    }

    [TestMethod]
    public void HasValidSingletonConstructor_GenericValidSingleton_ReturnsTrue()
    {
        Assert.IsTrue(
            SingletonConstructorHelpers.HasValidSingletonConstructor<MockSingletonValid>()
        );
    }

    [TestMethod]
    public void SingletonInitializationException_PreservesMessage()
    {
        var exception = new SingletonInitializationException("initialization failed");

        Assert.AreEqual("initialization failed", exception.Message);
    }

    private class MultiplePublicConstructors : SingletonBase<MultiplePublicConstructors>
    {
        public MultiplePublicConstructors() { }

        public MultiplePublicConstructors(string value) { }
    }
}
