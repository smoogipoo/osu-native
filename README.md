# osu-native

Native tools for osu!

Work in progress. Help/usage scenarios welcomed :)

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
