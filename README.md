This project shows how to use Entity Framework Core (SQLite) with NativeAOT. You may also use it as a starting point for your projects.

## Prerequsities
- A native C++ build toolchain: MSVC or clang
- .NET 6.0 SDK

## Getting started
You need to clone this project to your local development environment first:

```bash
git clone https://github.dev/hez2010/EFCore.NativeAOT.git
cd EFCore.NativeAOT
```

Then you can build the project:

```bash
dotnet publish -c Release -r win-x64
```

`win-x64` can be replaced to other runtime identifiers, e.g. `linux-x64`, `osx-x64`, `linux-arm64`, `win-arm64` and etc.

The built dist will be placed in `publish` directory, for example,  `bin/Release/net6.0/win-x64/publish`.