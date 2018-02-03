function solve(input) {
    let towns = []
    for (let town of input.slice(1)){
        let [empty, townName, lat, long] = town.split(/\s*\|\s*/)
        let townObj = { Town: townName, Latitude: Number(lat), Longitude: Number(long) };
        towns.push(townObj)
    }
    return JSON.stringify(towns)
}