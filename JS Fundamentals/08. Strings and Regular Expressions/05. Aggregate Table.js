function solve(input){
    let resultTowns = []
    let sum = 0
    for(let line of input){
        let currentLine = line.split('|').filter(e=> e !=='')
        resultTowns.push(currentLine[0].trim())
        sum += parseInt(currentLine[1])
    }
    console.log(resultTowns.join(', '))
    console.log(sum)
}