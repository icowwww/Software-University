function solve(name, age, weight, height){
    let status =''
    let isObese = false
    let bmi = weight / (Number(height) / 100 * Number(height) / 100)
    if(bmi < 18.5)
        status = 'underweight'
    else if (bmi < 25)
        status = 'normal'
    else if (bmi < 30)
        status = 'overweight'
    else if (bmi >= 30) {
        status = 'obese'
        isObese = true
    }
    let obj = {
    name : name,
        personalInfo: {
        age: Math.round(Number(age)),
            weight: Math.round(Number(weight)),
            height: Math.round(Number(height))
        },
        BMI:  Math.round(bmi),
        status: status,
        recommendation: 'admission required'
    }
    if(!isObese)
        delete obj.recommendation
    return obj
}