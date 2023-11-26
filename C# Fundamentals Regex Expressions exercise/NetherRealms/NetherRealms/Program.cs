using System.Text.RegularExpressions;

const string healthPattern = @"[^+\-*/.\d]";
const string damagePattern = @"-?\d+(\.\d+)?";
const string operatorsPattern = @"\*|\/";

Console.ReadLine()?.Split(',', StringSplitOptions.TrimEntries).OrderBy(x => x).ToList()
    .ForEach(name =>
        {
            var health = Regex.Matches(name, healthPattern).Select(k => (int)char.Parse(k.Value)).Sum();
            var damage = Regex.Matches(name, damagePattern).Select(k => double.Parse(k.Value)).Sum();
            damage = Regex.Matches(name, operatorsPattern).Select(k => k.Value)
                .Aggregate(damage, (k, j) => j == "*" ? k * 2 : k / 2);

            Console.WriteLine($"{name} - {health} health, {damage:f2} damage");
        }
    );