function solve(n) {
    if (n===2)
    {
        console.log('+++')
        return
    }
    console.log('+' + '-'.repeat(n-2) + '+' + '-'.repeat(n-2) + '+')
    for (let i=1; i<=n/2-1.5; i++  )
        console.log('|' + ' '.repeat(n-2) + '|' + ' '.repeat(n-2) + '|')
    console.log('+' + '-'.repeat(n-2) + '+' + '-'.repeat(n-2) + '+')
    for (let i=1; i<=n/2-1.5; i++  )
        console.log('|' + ' '.repeat(n-2) + '|' + ' '.repeat(n-2) + '|')
    console.log('+' + '-'.repeat(n-2) + '+' + '-'.repeat(n-2) + '+')
}