function matchMultiplication(text) {
    let pattern = /-?\d+[ *.]+-?[\d].[\d]+/g;

    text = text.replace(pattern, (match) =>
    {
        let numbers = match.split('*').filter(x => x != '').map(Number);
        return numbers[0] * numbers[1];
    });
    console.log(text);
}