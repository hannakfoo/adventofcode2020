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
        public void ExecutePart1()
        {
            var luggageRules = File
               .ReadAllText(Directory.GetCurrentDirectory() + @"\days\day7\testinput.txt")
               .Replace("\r\n", "$$")
               .Split("$$")
               .ToList();

            var input = "shiny gold bag";
            var bagsThatCanContainShinyGoldBag = new List<string>();

            luggageRules.ForEach(rule =>
            {
                //Console.WriteLine(rule);
                var extractedRules = rule
                .Replace("contain", ",")
                .Split(",")
                .ToList();

                extractedRules.ForEach(er =>
                {
                    er = Regex.Replace(er, "[0-9]{1}", "").Trim();
                    var inputRule = new Regex(input);
                    if(inputRule.Match(er).Success)
                    {
                        if (!bagsThatCanContainShinyGoldBag.Contains(extractedRules[0]))
                        {
                            bagsThatCanContainShinyGoldBag.Add(extractedRules[0]);
                        }
                    }
                });

            });
            bagsThatCanContainShinyGoldBag.ForEach(er =>
            {
                
            });

            Console.ReadKey();
        }

        public void ExecutePart2()
        {
            throw new NotImplementedException();
        }
    }
}
