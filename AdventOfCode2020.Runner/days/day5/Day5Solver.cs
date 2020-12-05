using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using adventofcode2020.contracts;

namespace AdventOfCode2020.Runner.days.day5
{
    public class Day5Solver : ISolver
    {
        public void ExecutePart1()
        {
            var boardingPasses = File
                .ReadAllText(Directory.GetCurrentDirectory() + @"\days\day5\testinput.txt")
                .Replace("\r\n", "$$")
                .Split("$$")
                .ToList();

            // meaning of instructions:
            // F: Front 0 -127
            // B: Back
            // L: Left
            // R: Right

            // 8 columns

            boardingPasses.ForEach(boardingPass =>
            {
                var rowInstruction = boardingPass.Substring(0,7);
                Console.WriteLine($"rowinstruction:{rowInstruction}");
                var row = CalculateRowIndex(rowInstruction);
                var seatInstruction = boardingPass.Substring(7);
                Console.WriteLine($"seatInstruction:{seatInstruction}");
            });

            Console.WriteLine(boardingPasses);

            Console.WriteLine("Solved part 1 of day 5");
            Console.Read();
        }

        private int CalculateRowIndex(string rowInstruction)
        {
            var instructions = rowInstruction.ToList();

            int[] seats= new int[128];
            for (int i = 0; i < 128; i++)
            {
                seats[i] = i;
            }

            foreach (var seat in seats)
            {
                Console.WriteLine($"seat:{seat}");
            }

            var currentRange = 127;

            instructions.ForEach(instr =>
            {
                currentRange = GetRowRange(currentRange, instr);
            });


            // If F  => 0 - 63
            // If B  => 63 - 127

            //for (int i = 0; i < instructions.Length; i++)
            //{

            //}

            return 0;
        }

        private Range GetRowRange(Range currentRange, char instruction)
        {
            var result = currentRange.End;

            switch (instruction)
            {
                case 'F':
                    return Range.StartAt(result / 2);
                case 'B':
                    return Range.EndAt(result/ 2);
                default:
                    return new Range();
            }
        }

        public void ExecutePart2()
        {
            Console.WriteLine("Solved part 2 of day 5");
            Console.Read();
        }
    }
}
