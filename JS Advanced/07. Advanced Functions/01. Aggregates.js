function solve(arr) {
    console.log('Sum = ' + arr.reduce((a, b) => Number(a) + Number(b)))
    console.log('Min = ' + arr.reduce((a, b) => Math.min(Number(a) + Number(b))))
    console.log('Max = ' + arr.reduce((a, b) => Math.max(Number(a) + Number(b))))
    console.log('Product = ' + arr.reduce((a, b) => Math.min(Number(a) * Number(b))))
    console.log('Join = ' + arr.reduce((a, b) => a.toString() + b))
}