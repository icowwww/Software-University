function solve(input) {
    let words = {}
    let pattern = /\w+/g
    input = input[0].toLowerCase()
    let match = pattern.exec(input)
    while(match){
        if (!words.hasOwnProperty(match[0]))
            words[match[0]] = 0
        words[match[0]] += 1
        match = pattern.exec(input)
    }
    for (let word of Object.keys(words).sort(sort)){
        console.log('\'' + word + '\'' + ' -> ' + words[word] + ' times')
    }
    function sort(a,b) {
        if(a < b) return -1;
        if(a > b) return 1;
        return 0;
    }
}