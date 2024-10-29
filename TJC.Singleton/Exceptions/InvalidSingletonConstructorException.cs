namespace TJC.Singleton.Exceptions;

/// <summary>
/// This exception is thrown when a singleton class has an invalid constructor.
/// </summary>
/// <param name="message"></param>
public class InvalidSingletonConstructorException(string? message) : Exception(message);
