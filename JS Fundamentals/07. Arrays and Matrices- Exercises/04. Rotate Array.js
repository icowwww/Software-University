function solve(input) {
    let spins = input.pop()
    spins = spins%input.length
    for (let i=0; i<spins; i++){
        let currentNum = input.pop()
        input.unshift(currentNum)
    }
    console.log(input.join(' '))
}