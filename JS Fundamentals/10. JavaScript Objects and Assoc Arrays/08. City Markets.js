function solve(input) {
    let record = new Map();
    for (let line of input) {
        let [town, product, income] = line.split(' -> ');
        income = income.split(' : ').reduce((a, b) => a * b);
        if (!record.has(town)) {
            record.set(town, new Map());
        }
        if (!record.get(town).has(product)) {
            record.get(town).set(product, 0);
        }
        let oldIncome = record.get(town).get(product);

        record.get(town).set(product, oldIncome + income);
    }
    for (let [town, products] of record) {
        console.log(`Town - ${town}`);
        for (let [product, income] of products) {
            console.log(`$$$${product} : ${income}`);
        }
    }
}