function solve(num) {
    while(getAverage(num)<=5){
        num = (num *10) +9
    }
    console.log(num)
    function getAverage(number) {
        let sum = 0
        let length = number.toString().length
        while (number){
            sum += number%10
            number = Math.floor(number/10)
        }
        return sum/length
    }
}