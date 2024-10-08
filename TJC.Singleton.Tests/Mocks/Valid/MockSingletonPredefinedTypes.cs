namespace TJC.Singleton.Tests.Mocks.Valid;

/// <summary>
/// This singleton is an example of the proper intended use of the <see cref="SingletonBase{TMyClass}"/>.
/// </summary>
internal class MockSingletonPreDefinedTypes : SingletonBase<MockSingletonPreDefinedTypes>
{
    #region Constructor

    #endregion

    #region Predefined Types

    public static MockSingletonPreDefinedTypes Default { get; } = new() { Setting1 = "Setting1", Setting2 = "Setting2" };

    public static MockSingletonPreDefinedTypes Empty { get; } = new() { Setting1 = string.Empty, Setting2 = string.Empty };

    public static MockSingletonPreDefinedTypes Alphabet { get; } = new() { Setting1 = "ABC", Setting2 = "DEF" };

    public static MockSingletonPreDefinedTypes Numbers { get; } = new() { Setting1 = "123", Setting2 = "456" };

    #endregion

    #region Properties

    public string Setting1 { get; private set; } = "Setting1";

    public string Setting2 { get; private set; } = "Setting2";

    #endregion

    #region Methods

    public static void SetInstance(MockSingletonPreDefinedTypes value) =>
        SetBaseInstance(value);

    #endregion
}