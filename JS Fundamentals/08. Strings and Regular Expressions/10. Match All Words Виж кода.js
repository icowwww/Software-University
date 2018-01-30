function solve(input){
    let matches = input.match(/\w+/g)
    return matches.join('|')
}