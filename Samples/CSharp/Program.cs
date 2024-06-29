using osu.Native.Bindings;

string beatmap = args[0];
int ruleset = int.Parse(args[1]);
int mods = int.Parse(args[2]);

Lazer lazer = new Lazer();
lazer.Log += msg => Console.WriteLine($"[Lazer] : {msg}");

IDifficultyCalculator calculator = lazer.CreateDifficultyCalculator();
double sr = calculator.ComputeDifficulty(new FileInfo(beatmap), ruleset, (uint)mods);

Console.WriteLine(sr);
