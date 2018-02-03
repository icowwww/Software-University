function solve(arr) {
    let record = new Map()

    for (let obj of arr) {
        let [systemName, component, subcomponent] = obj.split(' | ')
        if (!record.has(systemName)) {
            record.set(systemName, new Map())
        }
        if (!record.get(systemName).has(component)) {
            record.get(systemName).set(component, [])
        }
        record.get(systemName).get(component).push(subcomponent)
    }
    record = [...record].sort((a, b) => {
        if (a[1].size > b[1].size) return -1
        if (a[1].size < b[1].size) return 1
        if(a[0].toLowerCase() < b[0].toLowerCase()) return -1
        if(a[0].toLowerCase() > b[0].toLowerCase()) return 1
    })
    for (let [system, components] of record) {
        console.log(system)
        components = [...components].sort((a, b) => {
            if (a[1].length > b[1].length) return -1
            if (a[1].length < b[1].length) return 1
        })
        for (let [component, subs] of components) {
            console.log(`|||${component}`)

            for (let sub of subs) {
                console.log(`||||||${sub}`)
            }
        }
    }
}