using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public class Day3
    {
        private char[] chars;
        private int priority = 0;

        public Day3()
        {
            chars = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (Char)i).ToArray();
            chars = chars.Concat(Enumerable.Range('A', 'Z' - 'A' + 1).Select(i => (Char)i).ToArray()).ToArray();
        }
        public async Task CallDay3MethodsAsync()
        {
            string[] input;
            using (Task<string[]> file = File.ReadAllLinesAsync(@"..\..\..\..\Day3Input.txt"))
            {
                input = await file;

            }

            PartOne(input);

            PartTwo(input);
        }

        public void PartOne(string[] input)
        {
            int priority = 0;
            foreach (var line in input)
            {
                var compartment1 = line.Substring(0, line.Length / 2);
                var compartment2 = line.Substring(line.Length / 2, line.Length / 2);
                //Console.WriteLine(line);
                //Console.WriteLine(compartment1);
                //Console.WriteLine(compartment2);
                foreach (var c in compartment2)
                {
                    if (compartment1.Contains(c))
                    {
                        priority += Array.IndexOf(chars,c) + 1;
                        break;
                    }
                }
            }
            Console.WriteLine(priority);
        }
        public void PartTwo(string[] input)
        {
            int priority = 0;

            int lineCount = 0;
            string[] lines = new string[3];

            foreach (var line in input)
            {
                var compartment1 = line.Substring(0, line.Length / 2);
                var compartment2 = line.Substring(line.Length / 2, line.Length / 2);
                if (lineCount < 3)
                {
                    lines[lineCount] = line;
                    lineCount++;
                }

                if(lineCount == 3)
                {
                    List<char> charMatch = new List<char>();
                    foreach (var c in lines[1])
                    {
                        if (lines[0].Contains(c))
                        {
                            charMatch.Add(c);
                        }
                    }
                    foreach (var c in lines[2])
                    {
                        if (charMatch.Contains(c))
                        {
                            charMatch.Add(c);
                            priority += Array.IndexOf(chars, c) + 1;
                            break;
                        }
                    }
                    lines = new string[3];
                    lineCount = 0;
                }
                
            }
            Console.WriteLine(priority);
        }
    }
}
