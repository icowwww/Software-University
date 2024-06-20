using System.Text;

namespace BakeryShop;

internal class Program
{
    private static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var foodInStock = new Dictionary<string, int>();
        var sb = new StringBuilder();
        var soldGoods = 0;
        while (input != "Complete")
        {
            var inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var command = inputArgs[0];
            var quantity = int.Parse(inputArgs[1]);
            var foodType = inputArgs[2];
            switch (command)
            {
                case "Receive" when !foodInStock.ContainsKey(foodType):
                    foodInStock.Add(foodType, quantity);
                    break;
                case "Receive":
                    foodInStock[foodType] += quantity;
                    break;
                case "Sell" when !foodInStock.ContainsKey(foodType):
                    sb.AppendLine($"You do not have any {foodType}.");
                    break;
                case "Sell":
                {
                    if (foodInStock[foodType] < quantity)
                    {
                        sb.AppendLine(
                            $"There aren't enough {foodType}. You sold the last {foodInStock[foodType]} of them.");
                        soldGoods += foodInStock[foodType];
                        foodInStock[foodType] = 0;
                    }
                    else
                    {
                        sb.AppendLine($"You sold {quantity} {foodType}.");
                        foodInStock[foodType] -= quantity;
                        soldGoods += quantity;
                    }

                    if (foodInStock[foodType] == 0) foodInStock.Remove(foodType);
                    break;
                }
            }
            input = Console.ReadLine();
        }

        foreach (var keyValuePair in foodInStock) sb.AppendLine($"{keyValuePair.Key}: {keyValuePair.Value}");

        sb.AppendLine($"All sold: {soldGoods} goods");
        Console.WriteLine(sb.ToString());
    }
}