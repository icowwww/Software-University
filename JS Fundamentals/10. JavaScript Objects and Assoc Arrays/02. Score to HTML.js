function solve(input) {
    let objects = JSON.parse(input)
    console.log('<table>')
    console.log('  <tr><th>name</th><th>score</th></tr>')
    for(let obj of objects){
        console.log('   <tr><td>' + htmlEscape(obj.name) + '</td><td>' + obj.score + '</td></tr>')
    }
    console.log('</table>')
    function htmlEscape(replaced) {
        replaced = replaced.split('&').join('&amp;');
        replaced = replaced.split('<').join('&lt;');
        replaced = replaced.split('>').join('&gt;');
        replaced = replaced.split('"').join('&quot;');
        replaced = replaced.split('\'').join('&#39;')
        return replaced
    }
}

