function format(tokens) {
    let xml = '<?xml version="1.0" encoding="UTF-8"?>\n';
    xml += '<quiz>\n';
    xml = templateFormat(tokens, xml);
    xml += '</quiz>';
    console.log(xml);

    function templateFormat(arr, str) {
        for (let i = 0; i < arr.length; i += 2) {
            let question = arr[i];
            let answer = arr[i + 1];

            str += '    <question>\n';
            str += `        ${question}\n`;
            str += '    </question>\n';

            str += '    <answer>\n';
            str += `        ${answer}\n`;
            str += '    </answer>\n';
        }
        return str;
    }
}