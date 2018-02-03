function solve(input) {
    let result ='<table>\n'
    for (let object of input){
        let obj = JSON.parse(object)
        result += '    <tr>\n'
        result += '        <td>' + obj.name + '</td>\n'
        result += '        <td>' + obj.position + '</td>\n'
        result += '        <td>' + obj.salary + '</td>\n'
        result += '    <tr>\n'
    }
    result += '</table>\n'
    return result
}