function solve(arr, argument){
    if(argument === 'desc'){
        arr.sort(function (a, b) { return b-a })
    }
    else
        arr.sort(function (a, b) { return a-b })
    return arr
}



solve([14, 7, 17, 6, 8], 'desc');