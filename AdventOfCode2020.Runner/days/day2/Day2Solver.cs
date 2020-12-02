using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adventofcode2020.contracts;

namespace AdventOfCode2020.Runner.days.day2
{
    public class Day2Solver : ISolver
    {
        public void ExecutePart1()
        {
            // Read input and split on space
            var inputLines = File.ReadLines(Directory.GetCurrentDirectory() + @"\days\day2\input.txt");
            var inputArray = new List<string>();
            var result = new List<bool>();
            int i = 1;
            foreach (var inputLine in inputLines)
            {
                inputArray.Add(inputLine);
                var passwordSpec = inputLine.Split(' ', StringSplitOptions.None);
             
                PasswordSpecification specification = new PasswordSpecification()
                {
                    MinOccurence = Convert.ToInt32(passwordSpec[0].Substring(0, passwordSpec[0].IndexOf('-'))),
                    MaxOccurence = Convert.ToInt32(passwordSpec[0].Substring(passwordSpec[0].IndexOf('-')+1)),
                    Character = passwordSpec[1].Replace(':', ' '),
                    PasswordValue = passwordSpec[2]
                };
                //
                result.Add(specification.IsValid());
                if (specification.IsValid())
                {
                    Console.WriteLine($"{i}:{specification.IsValid().ToString()}-{specification.Character}->{specification.PasswordValue}({specification.MinOccurence}-{specification.MaxOccurence})");
                }

                i++;
            }
            Console.WriteLine(result.Count(r => r));
            Console.WriteLine("Solved part 1");
            Console.ReadKey();
        }

        public void ExecutePart2()
        {
            // Read input and split on space
            var inputLines = File.ReadLines(Directory.GetCurrentDirectory() + @"\days\day2\input.txt");
            var inputArray = new List<string>();
            var result = new List<bool>();
            int i = 1;
            foreach (var inputLine in inputLines)
            {
                inputArray.Add(inputLine);
                var passwordSpec = inputLine.Split(' ', StringSplitOptions.None);

                PasswordSpecification specification = new PasswordSpecification()
                {
                    MinOccurence = Convert.ToInt32(passwordSpec[0].Substring(0, passwordSpec[0].IndexOf('-'))),
                    MaxOccurence = Convert.ToInt32(passwordSpec[0].Substring(passwordSpec[0].IndexOf('-') + 1)),
                    Character = passwordSpec[1].Replace(':', ' '),
                    PasswordValue = passwordSpec[2]
                };
                //
                result.Add(specification.IsValid2());
                if (specification.IsValid2())
                {
                    Console.WriteLine($"{i}:{specification.IsValid2().ToString()}-{specification.Character}->{specification.PasswordValue}({specification.MinOccurence}-{specification.MaxOccurence})");
                }

                i++;
            }
            Console.WriteLine(result.Count(r => r));
            Console.WriteLine("Solved part 2");
            Console.ReadKey();
        }
    }

    public class PasswordSpecification
    {
        public int MinOccurence { get; set; }

        public int MaxOccurence { get; set; }

        public string Character { get; set; }

        public string PasswordValue { get; set; }

        public bool IsValid()
        {
            // todo determine if this passwordvalue is valid
            var numberCount = PasswordValue.ToCharArray().Count(p => p.Equals(Character.ToCharArray()[0]));
            return ((numberCount >= MinOccurence) && (numberCount <= MaxOccurence));
        }

        public bool IsValid2()
        {
            // todo determine if this passwordvalue is valid
            var matchFirstPos = PasswordValue[MinOccurence - 1] == Character.ToCharArray()[0];
            var matchLastPos = PasswordValue[MaxOccurence - 1] == Character.ToCharArray()[0];

            if (matchFirstPos && matchLastPos)
            {
                return false;
            }

            return matchFirstPos || matchLastPos;
        }
    }
}
