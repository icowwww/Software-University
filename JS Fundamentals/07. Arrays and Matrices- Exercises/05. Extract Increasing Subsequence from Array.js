function solve(input) {
    let currentNum = Number.NEGATIVE_INFINITY
    let result=[]
    for (let i=0; i<input.length;i++){
        if (input[i] >= currentNum){
            result.push(input[i])
            currentNum=input[i]
        }
    }
    return result.join('\n')
}

console.log(solve([1,3,8,,'se',10,12,3,2,24]))