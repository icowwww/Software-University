function solve(input) {
    let sum1 =0
    let sum2 = 0
    let matrix = input
        .map(row => row.split(' ').map(Number)
        )
    for(let i=0; i<matrix.length;i++){
        sum1 += matrix[i][i]
        sum2 += matrix[matrix.length-1-i][i]
    }
    if(sum1!==sum2){
        matrix.forEach(e=> console.log(e.join(' ')))
    }
    else {
        for(i=0; i<matrix.length;i++){
            for(j=0; j<matrix.length;j++){
                if(i !== j && j+i !== matrix.length-1){
                    matrix[i][j] = sum1
                }
            }
        }
        matrix.forEach(e=> console.log(e.join(' ')))
    }
}