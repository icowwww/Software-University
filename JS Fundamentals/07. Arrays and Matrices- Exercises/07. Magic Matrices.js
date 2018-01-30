function solve(input) {
    let sum = input[0].reduce((a,b) => a+b,0)
    console.log(checkMagical(input))

    function checkMagical(input){
        for(let i=0; i<input.length; i++){
            if(input[i].reduce((a,b) => a+b,0) !== sum)
                return false;
            for (let k=0; k<input[i].length; k++){
                let currentSum= 0
                for (let j=0; j<input.length; j++){
                    currentSum = currentSum + input[i][j]
                }
                if(currentSum !== sum)
                    return false
            }
        }
        return true
    }
}