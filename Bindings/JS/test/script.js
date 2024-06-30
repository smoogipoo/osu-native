import Lazer from 'smoogipoo.osu-native';
import { readFile } from 'fs/promises';

(async function main() {
    const osu = await Lazer.create();
    const beatmap = await readFile('test-beatmap.osu', 'utf8');
    console.log(await osu.computeDifficulty(beatmap, 0, 0));
})();
