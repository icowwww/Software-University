function solve(input) {
    let arr = []
    let currentNumber = 0
    for (let command of input){
        currentNumber++
        if(command === 'add')
            arr.push(currentNumber)
        else if(command === 'remove')
            arr.pop()
    }
    if (arr.length ===0)
        return 'Empty'
    return arr.join('\n')
}

solve()