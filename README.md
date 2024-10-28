<div align="center">

[![npmjs](https://badge.fury.io/js/smoogipoo.osu-native.svg)](https://badge.fury.io/js/smoogipoo.osu-native)
[![NuGet version](https://badge.fury.io/nu/smoogipoo.osu.Native.Bindings.svg)](https://badge.fury.io/nu/smoogipoo.osu.Native.Bindings)

</div>

# osu-native

Native tools for osu!

> [!CAUTION]
>
> Work in progress. API is unstable. Usage scenarios/requests welcome!

## Usage

Check out the [samples](https://github.com/smoogipoo/osu-native/tree/master/Samples)!

## Building / Running

### Desktop:

```sh
# Build the native project -> ./artifacts/publish/osu.Native/release/
dotnet publish --ucr ./Sources/osu.Native/osu.Native.csproj

# Run the sample project
dotnet run --project Samples/CSharp/Samples.CSharp.csproj -- <beatmap_file> <ruleset_id> <mods_int>
```

### WebAssembly:

```sh
# Build the native project -> ./artifacts/publish/osu.Native.WebAssembly/release/ 
dotnet publish ./Sources/osu.Native.WebAssembly/osu.Native.WebAssembly.csproj

# Run the sample project
python3 -m http.server --directory ./artifacts/publish/osu.Native.WebAssembly/release/wwwroot

# Navigate to http://localhost:8000
```
