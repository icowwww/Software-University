function solve(input) {
    let pattern = /\b[A-Za-z]+\b/g
    let words = {}
    let match = pattern.exec(input)
    while(match){
        if(!words.hasOwnProperty(match[0])){
            words[match[0]] = 0
        }
        words[match[0]] += 1
        match = pattern.exec(input)
    }
    return JSON.stringify(words)

}