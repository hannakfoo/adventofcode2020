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

            app.VersionOption("-V --version", "1", "1.0");

            return app.Execute(args);
        }
    }
}
