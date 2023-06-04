using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public class Day1
    {

        public async Task StepOneAsync()
        {
            string[] lines;

            using (Task<string[]> file = File.ReadAllLinesAsync("C:\\Users\\Thanos\\Documents\\Visual Studio 2022\\Projects\\AdventOfCode2022\\ElfCalories.txt"))
            {
                lines = await file;
            }

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
            var input = new List<string>(lines);

            var topElf = 0;
            int elfIndex = 0;
            int currentIndex = 1;
            var currentCalories = 0;

            foreach (string line in input)
            {
                if(line == "" || input.Count() == currentIndex)
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

            Console.WriteLine($"part one: {topElf}");
        }

        public async Task StepTwoAsync()
        {
            string[] lines;

            using (Task<string[]> file = File.ReadAllLinesAsync("C:\\Users\\Thanos\\Documents\\Visual Studio 2022\\Projects\\AdventOfCode2022\\ElfCalories.txt"))
            {
                lines = await file;
            }

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
            var input = new List<string>(lines);

            var topThreeElvesSum = 0;
            var currentCalories = 0;
            int currentIndex = 1;

            var topThreeElves = new List<int>();

            foreach (string line in input)
            {
                if (line == "" || input.Count() == currentIndex)
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
                Console.WriteLine($"elf: {elf}");
                topThreeElvesSum += elf;
            }

            Console.WriteLine($"part two: {topThreeElvesSum}");
        }

    }

    


}
