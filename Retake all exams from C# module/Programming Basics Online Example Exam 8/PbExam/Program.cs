using System.Text;

namespace PbExam;

internal class Program
{
    private static void Main(string[] args)
    {
        //Programming Basics Online Example Exam 8 - Time needed 1:20H
        //01. Fruit Market
        //var strawbrPricePerKg = double.Parse(Console.ReadLine());
        //var bananaKgs = double.Parse(Console.ReadLine());
        //var orangeKgs = double.Parse(Console.ReadLine());
        //var raspbrKgs = double.Parse(Console.ReadLine());
        //var strawbrKgs = double.Parse(Console.ReadLine());
        //var raspbrPricePerKg = strawbrPricePerKg / 2.0;
        //var orangesPrice = raspbrPricePerKg * 0.6 * orangeKgs;
        //var bananasPrice = raspbrPricePerKg * 0.2 * bananaKgs;
        //
        //var strawbrPrice = strawbrPricePerKg * strawbrKgs;
        //var raspbrPrice = raspbrPricePerKg * raspbrKgs;
        //
        //var price = strawbrPrice + raspbrPrice + orangesPrice + bananasPrice;
        //
        //Console.WriteLine(price);

        //02. Safari
        //double tourGuidePrice = 100, fuelPricePerL = 2.10;
        //var budget = double.Parse(Console.ReadLine());
        //var fuelPrice = double.Parse(Console.ReadLine()) * fuelPricePerL;
        //var day = Console.ReadLine();
        //
        //var price = fuelPrice + tourGuidePrice;
        //var priceDiscount = day == "Saturday" ? price * 0.9 : price * 0.8;
        //
        //if (budget >= priceDiscount)
        //{
        //    Console.WriteLine($"Safari time! Money left: {(budget - priceDiscount):0.00} lv.");
        //    return;
        //}
        //
        //Console.WriteLine($"Not enough money! Money needed: {priceDiscount - budget:0.00} lv.");

        //03. Mobile operator
        //var oneYearPrices = new Dictionary<string, double>
        //{
        //    ["Small"] = 9.98,
        //    ["Middle"] = 18.99,
        //    ["Large"] = 25.98,
        //    ["ExtraLarge"] = 35.99
        //};
        //var twoYearPrices = new Dictionary<string, double>
        //{
        //    ["Small"] = 8.58,
        //    ["Middle"] = 17.09,
        //    ["Large"] = 23.59,
        //    ["ExtraLarge"] = 31.79
        //};
        //var contractPeriod = Console.ReadLine();
        //var contractType = Console.ReadLine();
        //var extraInternet = Console.ReadLine() == "yes" ? true : false;
        //var numberOfPayments = int.Parse(Console.ReadLine());
        //var monthPrice = contractPeriod == "one"
        //    ? oneYearPrices[contractType]
        //    : twoYearPrices[contractType];
        //var internetPriceMonth = 0.00;
        //if (extraInternet && monthPrice <= 10)
        //    internetPriceMonth = 5.50;
        //else if (extraInternet && monthPrice <= 30)
        //    internetPriceMonth = 4.35;
        //else if (extraInternet) internetPriceMonth = 3.85;
        //var finalPrice = contractPeriod == "one"
        //    ? monthPrice + internetPriceMonth
        //    : (monthPrice + internetPriceMonth) * 0.9625;
        //Console.WriteLine($"{finalPrice * numberOfPayments :0.00} lv.");

        //04. Tourist Shop
        //var budget = double.Parse(Console.ReadLine());
        //string inputArg1;
        //var numberOfItems = 0;
        //var spentMoney = 0.00;
        //
        //while ((inputArg1 = Console.ReadLine()) != "Stop")
        //{
        //    numberOfItems++;
        //    var price = numberOfItems % 3 == 0 ? double.Parse(Console.ReadLine()) * 0.5 : double.Parse(Console.ReadLine());
        //    
        //    if (budget >= price)
        //        budget -= price;
        //    else
        //    {
        //        Console.WriteLine($"You don't have enough money!\nYou need {price - budget:0.00} leva!");
        //        return;
        //    }
        //    spentMoney += price;
        //}
        //
        //Console.WriteLine($"You bought {numberOfItems} products for {spentMoney:0.00} leva.");

        //06. Vet Parking
        //var numberOfDays = int.Parse(Console.ReadLine());
        //var dailyUsage = int.Parse(Console.ReadLine());
        //
        //var evenDays = numberOfDays / 2;
        //var oddDays = numberOfDays - evenDays;
        //var evenHours = dailyUsage / 2;
        //var oddHours = dailyUsage - evenHours;
        //
        //var sumOddDay = evenHours * 1.25 + oddHours;
        //var sumEvenDay = oddHours * 2.5 + evenHours;
        //var total = sumOddDay * oddDays + sumEvenDay * evenDays;
        //
        //var sb = new StringBuilder();
        //for (var i = 1; i <= numberOfDays; i++)
        //    sb.AppendLine(i % 2 == 0 ? $"Day: {i} - {sumEvenDay:0.00} leva" : $"Day: {i} - {sumOddDay:0.00} leva");
        //
        //sb.AppendLine($"Total: {total:0.00} leva");
        //Console.WriteLine(sb.ToString());
    }
}