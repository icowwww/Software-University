function solve(input) {
    let number = Number(input[0])
    let precision = Number(input[1])

    if (precision > 15) {
        precision = 15
    }

    let x = number.toFixed(precision)
    console.log(parseFloat(x))
}