namespace FishingCompetition;

internal class Program
{
    private static void Main(string[] args)
    {
        var areaSize = int.Parse(Console.ReadLine());
        var areaMatrix = new string[areaSize];
        var currRowPos = -1;
        var currColPos = -1;
        var fishCount = 0.0;

        for (var i = 0; i < areaSize; i++)
        {
            var row = Console.ReadLine();
            areaMatrix[i] = row;
            var colPos = row.IndexOf('S');
            if (colPos == -1) continue;
            currRowPos = i;
            currColPos = colPos;
            areaMatrix[currRowPos] = row[..currColPos] + "-" + row[(currColPos + 1)..];
        }

        string command;
        while ((command = Console.ReadLine()) != "collect the nets")
        {
            if (command is "right" or "left")
                currColPos = GetNewPos(currColPos, areaSize, command == "right");
            else
                currRowPos = GetNewPos(currRowPos, areaSize, command == "down");

            var currLine = areaMatrix[currRowPos];
            var currChar = currLine[currColPos];
            if (char.IsDigit(currChar))
            {
                fishCount += char.GetNumericValue(currChar);
                areaMatrix[currRowPos] =
                    string.Concat(currLine.AsSpan()[..currColPos], "-", currLine.AsSpan(currColPos + 1));
            }
            else if (currChar == 'W')
            {
                Console.WriteLine(
                    $"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{currRowPos},{currColPos}]");
                return;
            }
        }

        Console.WriteLine(fishCount >= 20
            ? "Success! You managed to reach the quota!"
            : $"You didn't catch enough fish and didn't reach the quota! You need {20 - fishCount} tons of fish more.");

        if (fishCount > 0)
            Console.WriteLine($"Amount of fish caught: {fishCount} tons.");

        var rowString = areaMatrix[currRowPos];
        areaMatrix[currRowPos] = string.Concat(rowString.AsSpan()[..currColPos], "S", rowString.AsSpan(currColPos + 1));

        Console.WriteLine(string.Join("\n", areaMatrix));
    }

    private static int GetNewPos(int currPos, int areaSize, bool direction)
    {
        if (!direction)
            currPos = currPos - 1 < 0 ? areaSize - 1 : currPos - 1;
        else
            currPos = currPos + 1 >= areaSize ? 0 : currPos + 1;

        return currPos;
    }
}