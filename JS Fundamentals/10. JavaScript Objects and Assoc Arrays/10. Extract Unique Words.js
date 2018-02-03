function solve(input) {
    let set = new Set()
    for(let line of input){
        let words = line.split(/\W+/g).filter(w => w !== '').map(w=> w.toLowerCase())
        for(let word of words){
            set.add(word)
        }
    }
    return Array.from(set).join(', ')
}