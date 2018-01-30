function solve(input) {
    let str =''
    for(let word of input)
        str += word
    let splitString = str.split('')
    let reversedArray = splitString.reverse()
    return reversedArray.join("")
}