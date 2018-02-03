function solve(input) {
    let heroes = []
    for(let line of input){
        let lineArgs = line.split('/ ')
        let name = lineArgs[0].trim()
        let level = parseInt(lineArgs[1])
        let items =[]
        if(lineArgs.length > 2)
            items = lineArgs[2].split(', ')
        heroes.push({name: name, level: level, items: items})
    }
    console.log(JSON.stringify(heroes))
}