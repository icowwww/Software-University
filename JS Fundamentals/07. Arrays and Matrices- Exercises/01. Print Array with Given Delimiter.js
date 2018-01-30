function solve(input) {
    let delimiter = input[input.length-1]
    input.pop()
    return input.join(delimiter)
}