using System.Reflection;
using System.Linq;

namespace _02BlackBoxInteger
{
    using System;

    class BlackBoxIntegerTests
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var type = typeof(BlackBoxInt);
            var box = (BlackBoxInt)Activator.CreateInstance(type, true);

            while (input != "END")
            {
                var inputArgs = input.Split('_');
                var methodName = inputArgs[0];
                var value = int.Parse(inputArgs[1]);

                type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                    .First(x => x.Name.Contains(methodName)).Invoke(box,new object[] {value});

                var innerValue = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First().GetValue(box);

                Console.WriteLine(innerValue);
                input = Console.ReadLine();
            }
        }
    }
}
