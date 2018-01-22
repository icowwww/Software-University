function solve(a, b, c) {
    let d = Math.pow(b, 2) - (4 * a * c)
    if (d<0)
        return "No"
    if (d===0)
        return (-1 * b + Math.sqrt(d)) / (2 * a)
    else {
        let result = (-1 * b - Math.sqrt(d)) / (2 * a)
        let result2 = (-1 * b + Math.sqrt(d)) / (2 * a)
        return (result + "<br>" + result2)
    }
}