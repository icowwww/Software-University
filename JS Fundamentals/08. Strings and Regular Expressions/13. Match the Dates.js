function solve(input){
    let pattern = /\b([0-9]{1,2})-([A-Z][a-z]{2})-([0-9]{4})\b/g
    let dates = [], match;

    for (let currentSentence of input) {
        let match = pattern.exec(currentSentence);

        while (match) {
            dates.push(match[0] + ` (Day: ${match[1]}, Month: ${match[2]}, Year: ${match[3]})`);
            match = pattern.exec(currentSentence)
        }
    }
    console.log(dates.join(`\n`));
}