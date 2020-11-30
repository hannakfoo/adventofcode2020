using System;
using System.Collections.Generic;
using System.Linq;
using adventofcode2020.contracts;
using McMaster.Extensions.CommandLineUtils;

namespace adventofcode
{
    class Program
    {
        public static void Main(string[] args)
        {
            var app = new CommandLineApplication()
            {
                Name = "aoc-2020",
                Description = "=>> Advent of Code 2020 Runner <<="
            };

            Console.WriteLine("AdventOfCode Solver");
            Console.WriteLine("Please give in the day you want to execute:");

            var puzzle = Console.ReadLine();
            var classes = GetAllSolvers();

            var classToExecute = classes.FirstOrDefault(n => n.Contains($"Day{puzzle}"));

            if (classToExecute == null) throw new NullReferenceException();
            var type = Type.GetType(classToExecute);

            if (type != null)
            {
                var solver = Activator.CreateInstance(type) as ISolver;
                solver.ExecutePart1();
                solver.ExecutePart2();
            }

            Console.WriteLine("Program has come to an end, please press any key to exit");
            app.VersionOption("-V --version", "1", "1.0");

            app.Execute(args);
        }

        public static List<string> GetAllSolvers()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(ISolver).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => x.FullName).ToList();
        }
    }
}
