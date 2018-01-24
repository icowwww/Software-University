function printDna(n) {
    let structure = 'ATCGTTAGGG'
    let max = 10
    let sIndex = -1
    for (let i = 1; i <= n; i++) {
        let char1 = structure.charAt(getIndex())
        let char2 = structure.charAt(getIndex())
        if (i % 4 === 1) {
            console.log(`**${char1}${char2}**`)
        } else if (i % 4 === 2 || i % 4 === 0) {
            console.log(`*${char1}--${char2}*`)
        } else {
            console.log(`${char1}----${char2}`)
        }
    }

    function getIndex() {
        sIndex += 1
        if (sIndex === max) {
            sIndex = 0
        }
        return sIndex
    }
}