[![NuGet Version and Downloads count](https://buildstats.info/nuget/TJC.Singleton)](https://www.nuget.org/packages/TJC.Singleton)

This singleton base & factory can be used to instantiate all singletons at once.

---
## [SingletonBase](./TJC.Singleton/SingletonBase.cs)
- Ensures that *only* one **instance** of a **derived class** will exist.
- This is implemented in a thread-safe way using **Lazy**.
- It also ensures that the derived class has a **private** or **protected** constructor by throwing an **exception** at run-time.

### Examples
- [This mock class](./TJC.Singleton.Tests/Mocks/Valid/MockSingletonValid.cs) shows a example use-case.

---
## [SingletonFactory](./TJC.Singleton/Factories/SingletonFactory.cs)
- Can be used to instantiate **ALL** classes that derive from [SingletonBase](./TJC.Singleton/SingletonBase.cs).