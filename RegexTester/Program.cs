using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RegexTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var patterns = new List<string> { "^[1|2][9|0]$" };

            var inputs = new List<string>();

            for (int i = 1900; i < 2025; i++)
            {
                inputs.Add(i.ToString());
            }

            patterns.ForEach(pattern =>
            {
                Console.WriteLine($"Regular Expression {pattern}");
                var regex = new Regex(pattern);
                inputs.ForEach(input =>
                {
                    Console.WriteLine($"{input}");
                    var isMatch = regex.IsMatch(input);
                    Console.WriteLine($"{isMatch}");
                });

            });
            

            Console.ReadKey();
        }
    }
}
