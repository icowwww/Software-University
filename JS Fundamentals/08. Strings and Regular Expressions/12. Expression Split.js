function solve(input) {
    let elements = input.split(/[\s.();,]+/).filter(each => each != '');
    console.log(elements.join("\n"));
}