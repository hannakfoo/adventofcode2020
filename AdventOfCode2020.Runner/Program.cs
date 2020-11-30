using System;
using McMaster.Extensions.CommandLineUtils;

namespace adventofcode
{
    class Program
    {
        public static int Main(string[] args)
        {
            var app = new CommandLineApplication()
            {
                Name = "aoc-2020",
                Description = "=>> Advent of Code 2020 Runner <<="
            };
            app.HelpOption(inherited: true);

            app.OnExecute(() =>
            {
                Console.WriteLine("Geef een parameter op!");
                app.ShowHelp();
                return 1;
            });

            return app.Execute(args);
        }
    }
}
