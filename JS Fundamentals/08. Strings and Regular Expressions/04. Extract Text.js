function solve(input){
    let pattern = /\((.+?)\)/g
    let dates = [];

    let match = pattern.exec(input);

    while (match) {
        dates.push(`${match[1]}`)
        match = pattern.exec(input)
    }

    console.log(dates.join(`, `));
}