interface Osu {
    ComputeDifficulty(beatmapContent: string, rulesetId: number, mods: number): Promise<number>;
}

export default class Lazer {
    static async create(): Promise<Lazer> {
        const { dotnet } = await import('./_framework/dotnet.js');
        const instance = new Lazer();

        const { getAssemblyExports, getConfig } = await dotnet
            .withDiagnosticTracing(false)
            .create();

        instance.osu = (await getAssemblyExports(getConfig().mainAssemblyName)).Program;

        return instance;
    }

    async computeDifficulty(beatmapContent: string, rulesetId: number, mods: number): Promise<number> {
       return await this.osu.ComputeDifficulty(beatmapContent, Number(rulesetId), mods);
    }

    private osu!: Osu;
}
