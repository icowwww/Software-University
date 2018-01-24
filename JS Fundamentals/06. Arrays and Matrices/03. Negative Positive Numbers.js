function solve(input) {
    let arr = []
    for(i=0;i<input.length;i++){
        if (input[i]<0)
            arr.unshift(input[i])
        else
            arr.push(input[i])
    }
    arr.forEach(e=> console.log(e))
}