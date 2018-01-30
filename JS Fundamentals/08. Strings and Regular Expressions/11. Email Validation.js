function solve(input){
    let pattern = /^[A-Za-z0-9]+@[a-z]+.[a-z]+$/g
    let result = pattern.test(input)
    if (result)
        return 'Valid'
    return 'Invalid'
}