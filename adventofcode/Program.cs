using adventofcode.dec1;
using adventofcode.dec10;
using adventofcode.dec11;
using adventofcode.dec2;
using adventofcode.dec3;
using adventofcode.dec4;
using adventofcode.dec5;
using adventofcode.dec6;
using adventofcode.dec7;
using adventofcode.dec8;
using adventofcode.dec9;
using System;

namespace adventofcode
{
    class Program
    {
        static void Main(string[] args)
        {
            var startTime = DateTime.Now;

            var day1 = ExpenseFinder.FindCorrect();
            Console.WriteLine($"day 1 : {day1}");

            var day2 = new PasswordChecker().GetNbValidPasswords();
            Console.WriteLine($"day 2 : {day2}");

            var day3 = new PathFinder().NbTree();
            Console.WriteLine($"day 3 : {day3}");

            var day4 = new PassportValidator().NbValidPassport();
            Console.WriteLine($"day 4 : {day4}");

            var day5 = new SeatFinder().FindSeat();
            Console.WriteLine($"day 5 : {day5}");

            var (day6P1, day6P2) = new Day6().GetAnswers();
            Console.WriteLine("Day 6");
            Console.WriteLine($"    part 1 : {day6P1}");
            Console.WriteLine($"    part 2 : {day6P2}");

            var (day7P1, day7P2) = new Day7().GetAnswers();
            Console.WriteLine("Day 7");
            Console.WriteLine($"    part 1 : {day7P1}");
            Console.WriteLine($"    part 2 : {day7P2}");

            var (day8P1, day8P2) = new Day8().GetAnswers();
            Console.WriteLine("Day 8");
            Console.WriteLine($"    part 1 : {day8P1}");
            Console.WriteLine($"    part 2 : {day8P2}");

            var (day9P1, day9P2) = new Day9().GetAnswers();
            Console.WriteLine("Day 9");
            Console.WriteLine($"    part 1 : {day9P1}");
            Console.WriteLine($"    part 2 : {day9P2}");

            var (day10P1, day10P2) = new Day10().GetAnswers();
            Console.WriteLine("Day 10");
            Console.WriteLine($"    part 1 : {day10P1}");
            Console.WriteLine($"    part 2 : {day10P2}");

            var (day11P1, day11P2) = new Day11().GetAnswers();
            Console.WriteLine("Day 11");
            Console.WriteLine($"    part 1 : {day11P1}");
            Console.WriteLine($"    part 2 : {day11P2}");

            Console.WriteLine("The end!");

            var endTime = DateTime.Now;
            Console.WriteLine($"Took {(int)(endTime - startTime).TotalMilliseconds}ms");

            Console.ReadKey();
        }
    }
}
