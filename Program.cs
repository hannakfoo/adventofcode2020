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
                Description = "Advent of Code 2020 Runner"
            };
            app.HelpOption(inherited: true);
            app.Command("config", configCmd =>
            {
                configCmd.OnExecute(() =>
                {
                    Console.WriteLine("Geef een parameter op");
                    configCmd.ShowHelp();
                    return 1;
                });

                configCmd.Command("day", setCmd =>
                {
                    setCmd.Description = "welke dag van de AoC wil je runnen?";
                    var key = setCmd.Argument("key", "Name of the config").IsRequired();
                    var val = setCmd.Argument("value", "Value of the config").IsRequired();
                    setCmd.OnExecute(() =>
                    {
                        Console.WriteLine($"Setting config {key.Value} = {val.Value}");
                    });
                });

                configCmd.Command("part", listCmd =>
                {
                    listCmd.Description = "Welk deel van de AoC wil je runnen?";
                    var json = listCmd.Option("--json", "Json output", CommandOptionType.NoValue);
                    listCmd.OnExecute(() =>
                    {
                        if (json.HasValue())
                        {
                            Console.WriteLine("{\"dummy\": \"value\"}");
                        }
                        else
                        {
                            Console.WriteLine("dummy = value");
                        }
                    });
                });
            });

            app.OnExecute(() =>
            {
                Console.WriteLine("Specify a subcommand");
                app.ShowHelp();
                return 1;
            });

            return app.Execute(args);
        }
    }
}
