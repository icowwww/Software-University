using System;

namespace BonusScoringSystem
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var studentsCount = int.Parse(Console.ReadLine());
            var lecturesCount = int.Parse(Console.ReadLine());
            var initialBonus = int.Parse(Console.ReadLine());

            var highestBonus = 0.0;
            var studentAttendances = 0;

            for (var i = 0; i < studentsCount; i++)
            {
                var currStudentAttends = int.Parse(Console.ReadLine());
                var currStudentBonus = (double) currStudentAttends / lecturesCount * (5 + initialBonus);

                if (!(currStudentBonus >= highestBonus)) continue;
                highestBonus = currStudentBonus;
                studentAttendances = currStudentAttends;
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(highestBonus)}.");
            Console.WriteLine($"The student has attended {studentAttendances} lectures.");
        }
    }
}