using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RegexTester
{
    class Program
    {
        static void Main(string[] args)
        {
            //1920 - 2002
            // first is 1 or 2
            // second is 9 or 0
            // third is 2 
            // 1970 - 2019
            //(19[789]\d | 20[01]\d)
            var patterns = new List<string> { @"19[23456789]\d|200[012]", @"20[1]\d|2020" };

            var inputs = new List<string>();

            for (int i = 1900; i < 2025; i++)
            {
                inputs.Add(i.ToString());
            }

            patterns.ForEach(pattern =>
            {
                //Console.WriteLine($"Regular Expression {pattern}");
                var regex = new Regex(pattern);
                inputs.ForEach(input =>
                {
                    var isMatch = regex.IsMatch(input);
                    Console.WriteLine($"{input}|{pattern}|:{isMatch}");
                });

            });
            

            Console.ReadKey();
        }
    }
}
