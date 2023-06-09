﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public class Day1
    {

        public async Task CallDay1MethodsAsync()
        {
            string[] lines;
            using (Task<string[]> file = File.ReadAllLinesAsync(@"..\..\..\..\ElfCalories.txt"))
            {
                lines = await file;
                
            }

            PartOne(lines);
            PartTwoLinq(lines);
            PartTwo(lines);
        }


        public void PartOne(string[] lines)
        {
            var topElf = 0;
            int elfIndex = 0;
            int currentIndex = 1;
            var currentCalories = 0;

            foreach (string line in lines)
            {
                if(line == "" || lines.Count() == currentIndex)
                {
                    if(line != "")
                        currentCalories += Convert.ToInt32(line);

                    if (topElf < currentCalories)
                    {
                        topElf = currentCalories;
                        currentCalories = 0;
                        elfIndex = currentIndex;
                    }
                    else
                    {
                        currentCalories = 0;
                    }
                }
                else
                {
                    currentCalories += Convert.ToInt32(line);
                }
                currentIndex++;
            }

            Console.WriteLine($"day 1 part one: {topElf}");
        }

        //Using LINQ
        public void PartTwoLinq(string[] lines)
        {

            //var input = new List<string>() {
            //    "1000",
            //    "2000",
            //    "3000",
            //    "",
            //    "4000",
            //    "",
            //    "5000",
            //    "6000",
            //    "",
            //    "7000",
            //    "8000",
            //    "9000",
            //    "",
            //    "10000"};

            var topThreeElvesSum = 0;
            var currentCalories = 0;
            int currentIndex = 1;

            var topThreeElves = new List<int>();

            foreach (string line in lines)
            {
                if (line == "" || line.Count() == currentIndex)
                {
                    if (line != "")
                        currentCalories += Convert.ToInt32(line);

                    topThreeElves.Add(currentCalories);
                    currentCalories = 0;
                }
                else
                {
                    currentCalories += Convert.ToInt32(line);
                }
                currentIndex++;
            }
            foreach(int elf in topThreeElves.OrderDescending().Take(3))
            {
                topThreeElvesSum += elf;
            }

            Console.WriteLine($"day 1 part two LINQ: {topThreeElvesSum}");
        }

        //Without LINQ
        public void PartTwo(string[] lines)
        {

            //var input = new List<string>() {
            //    "1000",
            //    "2000",
            //    "3000",
            //    "",
            //    "4000",
            //    "",
            //    "5000",
            //    "6000",
            //    "",
            //    "7000",
            //    "8000",
            //    "9000",
            //    "",
            //    "10000"};
            //var input = new List<string>(lines);

            var topThreeElvesSum = 0;
            var currentCalories = 0;
            int currentIndex = 1;

            int[] topThreeElves = new int[3];

            foreach (string line in lines)
            {
                if (line == "" || lines.Count() == currentIndex)
                {
                    if (line != "")
                        currentCalories += Convert.ToInt32(line);

                    for(int i = 2; i >= 0; i--)
                    {
                        if (currentCalories > topThreeElves[i])
                        {
                            if(i != 2)
                            {
                                topThreeElves[i + 1] = topThreeElves[i];
                            }
                            topThreeElves[i] = currentCalories;
                        }
                    }
                    currentCalories = 0;
                }
                else
                {
                    currentCalories += Convert.ToInt32(line);
                }
                currentIndex++;
            }
            foreach (int elf in topThreeElves)
            {
                topThreeElvesSum += elf;
            }

            Console.WriteLine($"day 1 part two: {topThreeElvesSum}");
        }

    }
}
