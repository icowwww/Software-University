function sumAndVatNumbers(numbers) {

    let sum = 0

    for (let num of numbers)
    {
        sum += num;
    }
    console.log("sum= " + sum)
    console.log("VAT= " + sum*0.2)
    console.log("total= " + sum*1.2)
}