
<div align="center">

[![npmjs](https://badge.fury.io/js/smoogipoo.osu-native.svg)](https://badge.fury.io/js/smoogipoo.osu-native)
[![NuGet version](https://badge.fury.io/nu/smoogipoo.osu.Native.Bindings.svg)](https://badge.fury.io/nu/smoogipoo.osu.Native.Bindings)

</div>

# osu-native

Native tools for osu!

> [!CAUTION]
>
> Work in progress. API is unstable. Usage scenarios/requests welcome!

## Building / Running

### Desktop:

```sh
# Build
dotnet publish -r <RID> ./Sources/osu.Native/osu.Native.csproj

# Output found in ./Sources/osu.Native.Desktop/bin/Release/<RID>/publish/
```

### WebAssembly:

```sh
# Build
dotnet publish ./Sources/osu.Native.WebAssembly/osu.Native.WebAssembly.csproj

# Run
cd ./Sources/osu.Native.WebAssembly/bin/Release/net8.0/publish/wwwroot
python3 -m http.server

# Navigate to http://localhost:8000
```
