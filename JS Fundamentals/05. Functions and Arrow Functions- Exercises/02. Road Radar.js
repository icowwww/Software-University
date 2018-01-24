function solve(input) {
    let km = parseInt(input[0])
    let limit = 0
    let zone = input[1]
    switch(zone){
        case 'motorway': limit = 130
            break;
        case 'interstate': limit = 90
            break;
        case 'city': limit = 50
            break;
        case 'residential': limit= 20
            break;
    }
    let overSpeed = km-limit
    if (overSpeed <=0){}
    else if (overSpeed <= 20)
        console.log('speeding')
    else if (overSpeed <= 40)
        console.log('excessive speeding')
    else if (overSpeed > 40)
        console.log('reckless driving')
}