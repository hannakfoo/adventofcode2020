using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adventofcode2020.contracts;

namespace AdventOfCode2020.Runner.days.day8
{
    public class Day8Solver : ISolver
    {
        public void ExecutePart1()
        {
            var bootSequence = File
                .ReadAllText(Directory.GetCurrentDirectory() + @"\days\day8\input.txt")
                .Replace("\r\n", "$$")
                .Split("$$")
                .ToList();

            var instructions = new List<Instruction>();

            bootSequence.ForEach(instruction =>
            {
                instructions.Add(new Instruction(instruction.Substring(0, 3), Convert.ToInt32(instruction.Substring(3))));
            });

            var accumlator = 0;

            var result = ExecuteBootCode(accumlator, instructions);
            Console.WriteLine($"Result:{result}");
            Console.WriteLine("Solved day 8");
            Console.Read();
        }

        private int ExecuteBootCode(int accumulator, List<Instruction> instructions)
        {

            for (int i = 0; i < instructions.Count;)
            {
                if (!instructions[i].HasBeenExecuted)
                {
                    switch (instructions[i].Command)
                    {

                        case "acc":
                            instructions[i].HasBeenExecuted = true;
                            accumulator += instructions[i].Steps;
                            i++;
                            break;
                        case "jmp":
                            instructions[i].HasBeenExecuted = true;
                            i += instructions[i].Steps;
                            break;
                        case "nop":
                            instructions[i].HasBeenExecuted = true;
                            i++;
                            break;
                    }
                }
                else
                {
                    return accumulator;
                }
            }

            return 0;
        }

        public void ExecutePart2()
        {
            throw new NotImplementedException();
        }
    }

    public class Instruction
    {
        public string Command { get; set; }

        public int Steps { get; set; }

        public bool HasBeenExecuted { get; set; }

        public Instruction(string command, int steps)
        {
            Command = command;
            Steps = steps;
            HasBeenExecuted = false;
        }
    }
}
