function solve(n, k) {
    let arr = [1]
    for (let i=1; i<n; i++){
        let arr2 = arr.slice(Math.max(0,i-k))
        arr.push(arr2.reduce((a, b) => a + b, 0))
    }
    return arr.forEach(e=> console.log(e))
}