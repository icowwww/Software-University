function solve(input){
    let s1 = (input[0]*1000) * (input[2]/3600)
    let s2 = (input[1]*1000) * (input[2]/3600)
    console.log(Math.abs(s1-s2))
}