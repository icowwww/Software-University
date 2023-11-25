using System.Text.RegularExpressions;

var healthRegex = new Regex(@"[^+\-*/.\d]");
var damageRegex = new Regex(@"-?\d+(\.\d+)?");
var operatorsRegex = new Regex(@"\*|\/");

Console.ReadLine()?.Split(',', StringSplitOptions.TrimEntries).OrderBy(x => x).ToList()
    .ForEach(name =>
        {
            var health = healthRegex.Matches(name).Select(k => (int)char.Parse(k.Value)).Sum();
            var damage = damageRegex.Matches(name).Select(k => double.Parse(k.Value)).Sum();
            damage = operatorsRegex.Matches(name).Select(k => k.Value)
                .Aggregate(damage, (k, j) => j == "*" ? k * 2 : k / 2);

            Console.WriteLine($"{name} - {health} health, {damage:f2} damage");
        }
    );