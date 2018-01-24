function solve(input) {
    let length = input.length
    let firstDiagonal =0
    let secondDiagonal = 0
    for (let i=0; i<length; i++){
        firstDiagonal += input[i][i]
    }
    for (let i=length-1; i>=0; i--){
        secondDiagonal += input[i][length-1-i]
    }
    console.log(firstDiagonal + ' ' + secondDiagonal)
}