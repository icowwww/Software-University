function solve(input) {
    console.log(input.reduce(function(a, b) { return a + b; }, 0))
    console.log(input.reduce(function(a, b) { return a + 1/b; }, 0))
    console.log(input.reduce(function(a, b) { return a + b }, ''))
}