namespace TJC.Singleton.Exceptions;

public class InvalidSingletonConstructorException(string? message) : Exception(message);