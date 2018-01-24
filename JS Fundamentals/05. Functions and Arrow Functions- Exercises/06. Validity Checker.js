function solve(input) {
    let x1 = parseInt(input[0])
    let y1 = parseInt(input[1])
    let x2 = parseInt(input[2])
    let y2 = parseInt(input[3])
    console.log(isValid(x1,y1,0,0))
    console.log(isValid(x2,y2,0,0))
    console.log(isValid(x1,y1,x2,y2))
    function isValid(x1,y1,x2,y2) {
        if(Math.sqrt((x2-x1)**2 + (y2-y1)**2)%1!==0)
            return '{'+x1 +', '+ y1+ '} to {'+x2+', '+y2+'} is invalid'
        return '{'+x1 +', '+ y1+ '} to {'+x2+', '+y2+'} is valid'
    }
}