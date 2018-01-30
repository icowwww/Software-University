function solve(input){
    let result = []
    for (let i=0; i< input.length; i++){
        let temp = input[i].split('@')
        let name = temp[0] + '.'
        let temp2 = temp[1].split('.')
        for (let j=0; j< temp2.length; j++){
            name = name + temp2[j].split('')[0]
        }
        result.push(name)
    }
    return result.join(', ')
}