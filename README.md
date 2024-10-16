<a href="https://github.com/TJC-Tools/TJC.Singleton/tags">
  <img alt="GitHub Tag" src="https://img.shields.io/github/v/tag/TJC-Tools/TJC.Singleton?style=for-the-badge&logo=tag&logoColor=white&labelColor=24292f&color=blue" />
</a>

<a href="https://github.com/TJC-Tools/TJC.Singleton/releases/latest">
  <img alt="GitHub Release" src="https://img.shields.io/github/v/release/TJC-Tools/TJC.Singleton?style=for-the-badge&logo=starship&logoColor=D9E0EE&labelColor=302D41&&color=green&include_prerelease&sort=semver" />
</a>

<a href="https://www.nuget.org/packages/TJC.Singleton">
  <img alt="NuGet Version" src="https://img.shields.io/nuget/v/TJC.Singleton?style=for-the-badge&logo=nuget&logoColor=white&labelColor=004880&color=blue" />
</a>

<br/>

<a href="https://www.nuget.org/packages/TJC.Singleton">
  <img alt="NuGet Downloads" src="https://img.shields.io/nuget/dt/TJC.Singleton?style=for-the-badge&logo=nuget&logoColor=white&labelColor=004880&color=yellow" />
</a>

<a href="https://github.com/TJC-Tools/TJC.Singleton">
  <img alt="Repository Size" src="https://img.shields.io/github/repo-size/TJC-Tools/TJC.Singleton?style=for-the-badge&logo=files&logoColor=white&labelColor=24292f&color=orange" />
</a>

<br/>

<a href="https://github.com/TJC-Tools/TJC.Singleton">
  <img alt="Last commit" src="https://img.shields.io/github/last-commit/TJC-Tools/TJC.Singleton?style=for-the-badge&logo=git&logoColor=D9E0EE&labelColor=302D41&color=mediumpurple"/>
</a>

<a href="LICENSE">
  <img alt="License" src="https://img.shields.io/github/license/TJC-Tools/TJC.Singleton.svg?style=for-the-badge&logo=balance-scale&logoColor=white&labelColor=333333&color=blueviolet" />
</a>

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
