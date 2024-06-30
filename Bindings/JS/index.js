import { dotnet } from './dotnet.js';

export default class Lazer {
    static async create() {
        const instance = new Lazer();

        const { getAssemblyExports, getConfig } = await dotnet
            .withDiagnosticTracing(false)
            .create();

        instance.osu = (await getAssemblyExports(getConfig().mainAssemblyName)).Program;

        return instance;
    }

    async computeDifficulty(beatmapContent, rulesetId, mods) {
       return await this.osu.ComputeDifficulty(beatmapContent, Number(rulesetId), mods);
    }
}
