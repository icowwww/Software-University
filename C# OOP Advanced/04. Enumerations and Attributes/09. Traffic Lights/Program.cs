using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    public static void Main()
    {
        var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var lightColors = input.Select(lightColor => (Color)Enum.Parse(typeof(Color), lightColor)).ToList();

        int updates = int.Parse(Console.ReadLine());
        for (int i = 0; i < updates; i++)
        {
            int realEnumUpdater = i + 1;
            Console.WriteLine(GetStringOfAllLights(lightColors, realEnumUpdater));
        }
    }

    private static string GetStringOfAllLights(List<Color> alLightColors, int realEnumUpdater)
    {
        var allColors = alLightColors.Select(color => (Color)(((int)color + realEnumUpdater) % 3)).Select(temp => temp.ToString()).ToList();
        return string.Join(" ", allColors);
    }
}
