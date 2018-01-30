function solve(input, words){
    for (let word of words){
        let replaceWith = '-'.repeat(word.length)
        while (input.indexOf(word) > -1) {
            input = input.replace(word, replaceWith)
        }
    }
    return input
}