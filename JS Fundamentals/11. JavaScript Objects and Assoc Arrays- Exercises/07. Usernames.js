function solve(input) {
    let hash = new Set()
    for(let name of input.sort(sorted)){
        hash.add(name)
    }
    hash.forEach(e=> console.log(e))
    function sorted(a,b){
        if(a.length > b.length)
            return 1
        if(a.length < b.length)
            return -1
        if(a.length = b.length){
            if(a < b)
                return -1
            if(a>b)
                return 1
            return 0
        }
    }
}