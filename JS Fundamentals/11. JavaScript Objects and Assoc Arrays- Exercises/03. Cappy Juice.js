function solve(input) {
    let juices = {}
    let bottles = {}
    for(let line of input){
        let lineArgs = line.split(' => ')
        let juice = lineArgs[0]//
        let amount = Number(lineArgs[1])
        if(!juices.hasOwnProperty(juice))
            juices[juice] = 0
        juices[juice] += amount
        if(juices[juice] >= 1000){
            if(!bottles.hasOwnProperty(juice))
                bottles[juice] = 0
            bottles[juice] += (juices[juice] - juices[juice] %1000) / 1000
            juices[juice] %= 1000
        }
    }
    for(let bottle of Object.keys(bottles)){
        console.log(bottle + ' => ' + bottles[bottle])
    }
}