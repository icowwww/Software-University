function solve(input) {
    let objects = {}
    for(let line of input){
        let firstChar = line[0]
        if(!objects.hasOwnProperty(firstChar))
            objects[firstChar] = []
        objects[firstChar].push(line)
    }
    for(let object of Object.keys(objects).sort()){
        console.log(object)
        objects[object].sort().map(e=> e.split(' : ').join(': ')).forEach(e=> console.log('  '+ e))
    }
}