using System.Text;

namespace OffroadChallenge;

internal class Program
{
    private static void Main(string[] args)
    {
        var fuel = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Reverse()
            .ToList();
        var consumption = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
            .ToList();
        var neededFuel = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
            .ToList();

        var sb = new StringBuilder();
        var elementsCount = fuel.Count();
        var altitudesReached = 0;
        Enumerable.Range(0, elementsCount)
            .TakeWhile(x => fuel[x] - consumption[x] >= neededFuel[x]).ToList().ForEach(x =>
            {
                altitudesReached++;
                sb.AppendLine($"John has reached: Altitude {x + 1}");
            });

        switch (altitudesReached)
        {
            case 0:
                sb.AppendLine("John did not reach: Altitude 1");
                sb.AppendLine("John failed to reach the top.");
                sb.AppendLine("John didn't reach any altitude.");
                break;
            case 4:
                sb.AppendLine("John has reached all the altitudes and managed to reach the top!");
                break;
            default:
                sb.AppendLine($"John did not reach: Altitude {altitudesReached + 1}");
                sb.AppendLine("John failed to reach the top.");
                var s = string.Join(", ", Enumerable.Range(1, altitudesReached).Select(x => "Altitude " + x));
                sb.AppendLine($"Reached altitudes: {s}");
                break;
        }

        Console.WriteLine(sb.ToString().TrimEnd());
    }
}