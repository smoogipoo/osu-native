const Lazer = require('smoogipoo.osu-native');
const { readFile } = require('fs').promises;

(async function main() {
    const osu = await Lazer.create();
    const beatmap = await readFile('test-beatmap.osu', 'utf8');
    console.log(await osu.computeDifficulty(beatmap, 0, 0));
})();
