function solve(input) {
    let towns = {}
    for(let town of input){
        let townArr = town.split(' <-> ')
        let name = townArr[0]
        let population = parseInt(townArr[1])
        if(!towns.hasOwnProperty(name))
            towns[name] = 0
        towns[name] += population
    }
    for(let town in towns){
        console.log(town + " : " + towns[town])
    }
}