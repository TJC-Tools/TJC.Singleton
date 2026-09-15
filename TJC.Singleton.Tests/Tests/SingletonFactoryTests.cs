using TJC.Singleton.Exceptions;
using TJC.Singleton.Factories;
using TJC.Singleton.Helpers;
using TJC.Singleton.Tests.Mocks.InvalidConstructors;
using TJC.Singleton.Tests.Mocks.Valid;

namespace TJC.Singleton.Tests.Tests;


public class SingletonFactoryTests
{
    [Fact]
    public void Instantiate_ValidSingleton_ReturnsTrue()
    {
        Assert.True(SingletonFactory.Instantiate<MockSingletonValid>());
    }

    [Fact]
    public void Instantiate_TypeWithoutInstanceProperty_ThrowsException()
    {
        Assert.Throws<Exception>(() => SingletonFactory.Instantiate<string>());
    }

    [Fact]
    public void GetSingletonConstructor_MultiplePublicConstructors_DescribesPluralConstructors()
    {
        var exception = Assert.Throws<InvalidSingletonConstructorException>(
            () => SingletonConstructorHelpers.GetSingletonConstructor(typeof(MultiplePublicConstructors))
        );

        Assert.Contains("constructors", exception.Message);
    }

    [Fact]
    public void HasValidSingletonConstructor_GenericValidSingleton_ReturnsTrue()
    {
        Assert.True(SingletonConstructorHelpers.HasValidSingletonConstructor<MockSingletonValid>());
    }

    [Fact]
    public void SingletonInitializationException_PreservesMessage()
    {
        var exception = new SingletonInitializationException("initialization failed");

        Assert.Equal("initialization failed", exception.Message);
    }

    private class MultiplePublicConstructors : SingletonBase<MultiplePublicConstructors>
    {
        public MultiplePublicConstructors() { }

        public MultiplePublicConstructors(string value) { }
    }
}