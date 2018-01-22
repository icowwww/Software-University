function solve(grad) {
    let degrees = (grad*0.9)%360
    if (degrees <0)
    {
        degrees = 360 + degrees
    }
    console.log(degrees)
}