function solve(input) {
    let biggestNum = Number.NEGATIVE_INFINITY
    for(let arr of input){
        for(let number of arr){
            if(number>biggestNum)
                biggestNum=number
        }
    }
    console.log(biggestNum)
}