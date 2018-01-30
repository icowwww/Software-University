function solve(input){
    let sum=0
    let items= []
    for (let i=0; i< input.length; i+=2){
        sum += parseFloat(input[i+1])
        items.push(input[i])
    }
    console.log('You purchased ' + items.join(', ') + ' for a total sum of ' + sum)
}