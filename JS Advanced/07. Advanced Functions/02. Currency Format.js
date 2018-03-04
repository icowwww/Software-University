function getDollarFormatter(formatter) {
    function dollarFormatter(value) {
        return formatter(',', '$', true, value);
    };
    return dollarFormatter;
}

console.log(getDollarFormatter(5345)); // $5345,00