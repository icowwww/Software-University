function solve(input) {
    let unit = Number(input);

    let foot = Math.floor(unit / 12);
    let inches = unit % 12;

    console.log(`${foot}'-${inches}"`);
}