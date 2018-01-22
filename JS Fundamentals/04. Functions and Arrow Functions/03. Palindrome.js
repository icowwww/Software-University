function solve(num) {
    for (let i=0; i<num.length; i++)
    {
        if (num[i] !== num[num.length-i-1])
            return false
    }
    return true
}