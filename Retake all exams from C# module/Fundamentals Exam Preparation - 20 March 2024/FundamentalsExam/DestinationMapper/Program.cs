using System.Text.RegularExpressions;

namespace DestinationMapper;

internal class Program
{
    private static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var regex = new Regex(@"([=\/])([A-Z][A-Za-z]{2,})\1");
        var travelPoints = 0;
        var matches = regex.Matches(input).Select(x => {
            travelPoints += x.Groups[2].Length;
            return x.Groups[2];
        });

        Console.WriteLine($"Destinations: {string.Join(", ", matches)}");
        Console.WriteLine($"Travel Points: {travelPoints}");
    }
}