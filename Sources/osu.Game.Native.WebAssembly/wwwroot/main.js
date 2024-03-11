// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

import {dotnet} from './_framework/dotnet.js'

const {getAssemblyExports, getConfig} = await dotnet
    .withDiagnosticTracing(false)
    .withApplicationArgumentsFromQuery()
    .create();

const config = getConfig();
const exports = await getAssemblyExports(config.mainAssemblyName);

let beatmap = null;
let rulesetId = 0;

function readFileAsText(file) {
    return new Promise((resolve, reject) => {
        const reader = new FileReader();
        reader.onload = event => resolve(event.target.result);
        reader.onerror = error => reject(error);
        reader.readAsText(file);
    });
}

async function updateStarRating() {
    if (beatmap === null)
        return;

    const startTime = new Date();
    const result = await exports.Program.ComputeDifficulty(beatmap, Number(rulesetId), 0);
    const endTime = new Date();

    document.getElementById('result').innerHTML = Math.round(result * 100) / 100;

    console.log(`took ${endTime - startTime}ms`)
}

document.getElementById('beatmap-file').addEventListener('change', async (event) => {
    beatmap = await readFileAsText(event.target.files[0]);
    await updateStarRating();
});

document.getElementById('ruleset-dropdown').addEventListener('change', async (event) => {
    rulesetId = event.target.value;
    await updateStarRating();
});