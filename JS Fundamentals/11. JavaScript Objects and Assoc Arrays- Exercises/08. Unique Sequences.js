function solve(input) {
    let result = new Set()
    for (let jsonArr of input){
        let arr = JSON.parse(jsonArr).sort((a,b)=> {
            if (a < b) return 1
            if (a > b) return -1
        })
        let stringArr = '[' + arr.join(', ') + ']'
        result.add(stringArr)
    }
    Array.from(result).sort((a,b) => {
        if(a.split(',').length-1 < b.split(',').length-1) return -1
        if(a.split(',').length-1 > b.split(',').length-1) return 1
    }).forEach(e=> console.log(e))
}