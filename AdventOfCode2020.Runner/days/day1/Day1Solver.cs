using System;
using System.Collections.Generic;
using System.IO;
using adventofcode2020.contracts;

namespace AdventOfCode2020.Runner.days.day1
{


    public class Day1Solver : ISolver
    {
        public void ExecutePart1()
        {
            var inputLines = File.ReadLines(Directory.GetCurrentDirectory() + @"\days\day1\input.txt");
            var inputArray = new List<int>();
            foreach (var inputLine in inputLines)
            {
                inputArray.Add(Convert.ToInt32(inputLine));
            }
            var result = FindEntriesAddingUp(inputArray, 2020);


            Console.WriteLine(result);

            Console.WriteLine("Solved Part 1");
            Console.ReadKey();

        }

        public int FindEntriesAddingUp(List<int> inputArray, int i)
        {
            foreach (var i1 in inputArray)
            {
                var temp = i - i1;

                if (inputArray.Contains(temp))
                {
                    return temp * i1;
                }
            }

            return 0;
        }

        public void ExecutePart2()
        {
            var inputLines = File.ReadLines(Directory.GetCurrentDirectory() + @"\days\day1\input.txt");
            var inputArray = new List<int>();
            foreach (var inputLine in inputLines)
            {
                inputArray.Add(Convert.ToInt32(inputLine));
            }
            var result = FindThreeEntriesAddingUp(inputArray, 2020);

            Console.WriteLine(result);

            Console.WriteLine("Solved Part 2");
            Console.ReadKey();
        }

        public int FindThreeEntriesAddingUp(List<int> inputArray, int i)
        {
            for (int j = 0; j < inputArray.Count; j++)
            {
                for (int k = j + 1; k < inputArray.Count; k++)
                {
                    for (int l = k + 1; l < inputArray.Count; l++)
                    {
                        if (inputArray[j] + inputArray[k] + inputArray[l] == i)
                        {
                            return inputArray[j] * inputArray[k] * inputArray[l];
                        }
                    }
                }
            }

            return 0;
        }
    }
}