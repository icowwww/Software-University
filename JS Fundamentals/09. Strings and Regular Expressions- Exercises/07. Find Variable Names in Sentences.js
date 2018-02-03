function solve(input) {
    let pattern= /_([0-9A-Za-z]+)/g
    let match = pattern.exec(input)
    let results = []
    while(match){
        results.push(match[1])
        match = pattern.exec(input)
    }
    return results.join(',')
}