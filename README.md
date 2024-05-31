# TJC Singleton
The singleton base class ensures that *only* one **instance** of a class will exist.

## Details
- This is done in a thread-safe way using a **Lazy** implementation.
- It also ensures that the derived class has a **private** or **protected** constructor by throwing an **exception** at run-time.

## Examples
- Please see [this mock class](./TJC.Singleton.Tests/Mocks/Valid/MockSingletonValid.cs) for an example of the intended use of the [SingletonBaseClass](./TJC.Singleton/SingletonBaseClass.cs).