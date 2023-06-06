using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022 // Note: actual namespace depends on the project name.
{
    public class Day2
    {

        private Dictionary<string, int> RockPaperScissors;
        private Dictionary<char, string> RockPaperScissorsEnemyLetters;
        private Dictionary<char, string> RockPaperScissorsPlayerLetters;

        private Dictionary<char, int> Indication;

        private int Loss = 0;
        private int Draw = 3;
        private int Win = 6;

        public Day2()
        {
            RockPaperScissors = new Dictionary<string, int>();
            RockPaperScissors.Add("Rock", 1);
            RockPaperScissors.Add("Paper", 2);
            RockPaperScissors.Add("Scissors", 3);

            RockPaperScissorsEnemyLetters = new Dictionary<char, string>();
            RockPaperScissorsEnemyLetters.Add('A', "Rock");
            RockPaperScissorsEnemyLetters.Add('B', "Paper");
            RockPaperScissorsEnemyLetters.Add('C', "Scissors");

            RockPaperScissorsPlayerLetters = new Dictionary<char, string>();
            RockPaperScissorsPlayerLetters.Add('X', "Rock");
            RockPaperScissorsPlayerLetters.Add('Y', "Paper");
            RockPaperScissorsPlayerLetters.Add('Z', "Scissors");

            Indication = new Dictionary<char, int>();
            Indication.Add('X', Loss);
            Indication.Add('Y', Draw);
            Indication.Add('Z', Win);

        }

        public async Task CallDay2MethodsAsync()
        {
            string[] lines;
            //using (Task<string[]> file = File.ReadAllLinesAsync("C:\\Users\\Thanos\\Documents\\Visual Studio 2022\\Projects\\AdventOfCode2022\\RockPaperScissors.txt"))
            using (Task<string[]> file = File.ReadAllLinesAsync(@"..\..\..\..\RockPaperScissors.txt"))
            {
                lines = await file;

            }

            PartOne(lines);
            PartTwo(lines);
        }

        public void PartOne(string[] lines)
        {
            //var input = new List<string>() {
            //    "A Y",
            //    "B X",
            //    "C Z"};

            string enemy;
            string player;
            int score = 0;
            int playerHandValue = 0;
            foreach (string line in lines)
            {
                enemy = RockPaperScissorsEnemyLetters[line.ToCharArray()[0]];
                player = RockPaperScissorsPlayerLetters[line.ToCharArray()[2]];

                playerHandValue = RockPaperScissors[player];
                if (enemy == "Rock")
                {
                    if (player == "Rock")
                    {
                        score += playerHandValue + Draw;
                    }
                    else if (player == "Paper")
                    {
                        score += playerHandValue + Win;
                    }
                    else
                    {
                        score += playerHandValue + Loss;
                    }
                }

                if (enemy == "Paper")
                {
                    if (player == "Rock")
                    {
                        score += playerHandValue + Loss;
                    }
                    else if (player == "Paper")
                    {
                        score += playerHandValue + Draw;
                    }
                    else
                    {
                        score += playerHandValue + Win;
                    }
                }

                if (enemy == "Scissors")
                {
                    if (player == "Rock")
                    {
                        score += playerHandValue + Win;
                    }
                    else if (player == "Paper")
                    {
                        score += playerHandValue + Loss;
                    }
                    else
                    {
                        score += playerHandValue + Draw;
                    }
                }
            }

            Console.WriteLine($"day 2 part 1: {score}");
        }

        public void PartTwo(string[] lines)
        {
            string enemy;
            int playerIndication;
            int score = 0;
            foreach (string line in lines)
            {
                enemy = RockPaperScissorsEnemyLetters[line.ToCharArray()[0]];
                playerIndication = Indication[line.ToCharArray()[2]];


                if (playerIndication == Loss)
                {
                    if (enemy == "Rock")
                    {
                        score += RockPaperScissors["Scissors"] + Loss;
                    }
                    else if (enemy == "Paper")
                    {
                        score += RockPaperScissors["Rock"] + Loss;
                    }
                    else if (enemy == "Scissors")
                    {
                        score += RockPaperScissors["Paper"] + Loss;
                    }
                }
                if (playerIndication == Win)
                {
                    if (enemy == "Rock")
                    {
                        score += RockPaperScissors["Paper"] + Win;
                    }
                    else if (enemy == "Paper")
                    {
                        score += RockPaperScissors["Scissors"] + Win;
                    }
                    else if (enemy == "Scissors")
                    {
                        score += RockPaperScissors["Rock"] + Win;
                    }
                }
                else if (playerIndication == Draw)
                {
                    score += RockPaperScissors[enemy] + Draw;
                }
            }

            Console.WriteLine($"day 2 part 2: {score}");
        }
    }

}