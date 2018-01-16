function colorfulNumbers(input) {
    let output = '<ul>\n'
    for (let i = 1; i<=input; i++)
    {
        if (i%2===0)
            output += ` <li><span style='color:${'blue'}>${i}</span></li>\n`;
        else {
            output += ` <li><span style='color:${'green'}>${i}</span></li>\n`;
        }
    }
    output += '</ul>'
    console.log(output)
}