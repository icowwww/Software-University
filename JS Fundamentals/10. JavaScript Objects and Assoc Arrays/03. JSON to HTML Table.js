function solve(input) {
    let objects = JSON.parse(input)
    let result = '<table>\n'
    result += '   <tr>'
    for(let key of Object.keys(objects[0])){
        result += '<th>' + key + '</th>'
    }
    result += '</tr>\n'
    for(let obj of objects){
        result += '   <tr>'
        for(let key of Object.keys(obj)){
            if(Number(obj[key]))
                result += '<td>' + obj[key] + '</td>'
            else
                result += '<td>' + htmlEscape(obj[key]) + '</td>'
        }
        result += '</tr>\n'
    }
    result += '</table>'
    return result
    function htmlEscape(replaced) {
        replaced = replaced.split('&').join('&amp;');
        replaced = replaced.split('<').join('&lt;');
        replaced = replaced.split('>').join('&gt;');
        replaced = replaced.split('"').join('&quot;');
        replaced = replaced.split('\'').join('&#39;')
        return replaced
    }
}