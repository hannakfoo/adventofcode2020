using adventofcode2020.contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020.Runner.days.day7
{
    public class Day7Solver : ISolver
    {
        private const string input = "shiny gold bag";
        public void ExecutePart1()
        {
            var luggageRules = File
               .ReadAllText(Directory.GetCurrentDirectory() + @"\days\day7\input.txt")
               .Replace("\r\n", "$$")
               .Split("$$")
               .ToList();

       
            var bagsThatCanContainShinyGoldBag = new List<string>();

            int i = 1;
             List<List<string>> rulesDictionary = new List<List<string>>();

            luggageRules.ForEach(rule =>
            {
                var extractedRules = rule
                .Replace("contain", ",")
                .Split(",")
                .ToList();

                var cleanupRules = CleanupRules(extractedRules);
                rulesDictionary.Add(cleanupRules);
                
                i++;
            });

            Console.WriteLine($"Lugage rules >> {luggageRules.Count}");

            Console.ReadKey();
        }

        private List<string> CleanupRules(List<string> extractedRules)
        {
            string cleanUpRule = string.Empty;
            List<string> result = new List<string>();

            foreach (var extractedRule in extractedRules)
            {
                cleanUpRule = Regex.Replace(extractedRule, "[0-9]{1}", "").Trim();
                result.Add(cleanUpRule);
            }

            return result;
        }

        public void ExecutePart2()
        {
            throw new NotImplementedException();
        }
    }
}
