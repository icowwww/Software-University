function solve2(input) {
    let words = input.split(/\W+/)
    let output= ''
    for (i=0; i< words.length ; i++){
        if (words[i].length !== 0)
            output += words[i].toUpperCase() + ', '
    }
    console.log(output.substring(0, output.length - 2))
}