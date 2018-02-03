function solve(input) {
    let pattern = /\d+/g
    let text = ''
    for(let line of input){
        text += line
    }
    let numbers = []
    let match = pattern.exec(text)
    while(match){
        numbers.push(match[0])
        match = pattern.exec(text)
    }
    return numbers.join(' ')
}