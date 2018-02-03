function solve(input) {
    let cars = {}
    for(let line of input){
        let lineArgs = line.split(' | ')
        let carBrand = lineArgs[0]
        let carModel = lineArgs[1]
        let producedCars = Number(lineArgs[2])
        if(!cars.hasOwnProperty(carBrand))
            cars[carBrand] = []
        if(!cars[carBrand].hasOwnProperty(carModel))
            cars[carBrand][carModel] = 0
        cars[carBrand][carModel] += producedCars
    }
    for(let model of Object.keys(cars))
    {
        console.log(model)
        for(let car of Object.keys(cars[model])){
            console.log('###' + car + ' -> ' + cars[model][car])
        }
    }
}