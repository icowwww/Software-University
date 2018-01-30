function solve(input){
    let pattern = /^([A-Z][a-zA-Z]*) - ([1-9][0-9]*) - ([A-Za-z0-9- ]+)$/g
    let dates = [], match;

    for (let currentSentence of input) {
        let match = pattern.exec(currentSentence);

        while (match) {
            dates.push(`Name: ${match[1]}\nPosition: ${match[3]}\nSalary: ${match[2]}`)
            match = pattern.exec(currentSentence)
        }
    }
    console.log(dates.join(`\n`));
}