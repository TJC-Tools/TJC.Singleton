namespace TJC.Singleton.Exceptions;

/// <summary>
/// This exception is thrown when a singleton fails to initialize.
/// </summary>
/// <param name="message"></param>
public class SingletonInitializationException(string? message) : Exception(message);