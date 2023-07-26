using AdventOfCode2022;
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var day1 = new Day1();
            await day1.CallDay1MethodsAsync();

            var day2 = new Day2();
            await day2.CallDay2MethodsAsync();

            var day3 = new Day3();
            await day3.CallDay3MethodsAsync();

        }
    }
}