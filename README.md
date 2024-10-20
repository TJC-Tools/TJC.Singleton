![GitHub Tag](https://img.shields.io/github/v/tag/TJC-Tools/TJC.Singleton) [![GitHub Release](https://img.shields.io/github/v/release/TJC-Tools/TJC.Singleton)](https://github.com/TJC-Tools/TJC.Singleton/releases/latest) [![NuGet Version](https://img.shields.io/nuget/v/TJC.Singleton)](https://www.nuget.org/packages/TJC.Singleton)

[![NuGet Downloads](https://img.shields.io/nuget/dt/TJC.Singleton)](https://www.nuget.org/packages/TJC.Singleton) ![Size](https://img.shields.io/github/repo-size/TJC-Tools/TJC.Singleton) [![License](https://img.shields.io/github/license/TJC-Tools/TJC.Singleton.svg)](LICENSE)

[![codecov](https://codecov.io/gh/TJC-Tools/TJC.Test/graph/badge.svg?token=92707C5KH4)](https://codecov.io/gh/TJC-Tools/TJC.Singleton)

This Singleton base & factory can be used to instantiate all Singletons at once.

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
