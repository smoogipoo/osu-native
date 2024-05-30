# osu-native-diffcalc

Produces C-style bindings for osu! difficulty calculation.

Work in progress. Help/usage scenarios welcomed :)

## Building / Running

### Desktop:

```sh
# Build
dotnet publish -r <RID> ./Sources/osu.Game.Native.Desktop/osu.Game.Native.Desktop.csproj

# Output found in ./Sources/osu.Game.Native.Desktop/bin/Release/<RID>/publish/
```

### WebAssembly:

```sh
# Build
dotnet publish ./Sources/osu.Game.Native.WebAssembly/osu.Game.Native.WebAssembly.csproj

# Run
cd ./Sources/osu.Game.Native.WebAssembly/bin/Release/net8.0/publish/wwwroot
python3 -m http.server

# Navigate to http://localhost:8000
```
