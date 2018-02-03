function solve(text, word) {
    let pattern = new RegExp('\\b' + word + '\\b', 'gi');
    let match = pattern.exec(text);
    let counter = 0;
    while (match !== null) {
        counter++;
        match = pattern.exec(text);
    }
    console.log(counter);
}