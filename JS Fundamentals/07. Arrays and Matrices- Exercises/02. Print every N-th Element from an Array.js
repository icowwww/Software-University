function solve(input) {
    let step = input.pop()
    input = input.filter((e,i)=> i%step ===0)
    return input.join('\n')
}

function solve2(input) {
    let step = input.pop()
    let result =[]
    for (let i=0; i< input.length; i++){
        if (i%step === 0)
        result.push(input[i])
    }
    return result.join('\n')
}