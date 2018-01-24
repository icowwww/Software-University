function solve(input) {
    let output=''
    for(i=0;i<input.length;i++){
        if (i%2===0)
            output+=input[i]+' '
    }
    return output.trim()
}