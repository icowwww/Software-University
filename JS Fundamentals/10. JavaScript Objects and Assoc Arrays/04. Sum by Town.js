function solve(input) {
    let objects = {}
    for(let i=0; i < input.length; i+=2){
        let name = input[i]
        let income = parseInt(input[i+1])
        if (!objects.hasOwnProperty(name)){
            objects[name] = 0
        }
        objects[name] += income
    }
    return JSON.stringify(objects)
}